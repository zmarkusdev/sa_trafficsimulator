using Datamodel;
using Repositories;
using SimulationUserInterface.Models;
using System;
using System.Collections.Generic;
using System.Windows.Threading;
using Technics;

namespace SimulationUserInterface.ViewModels
{
    public class MainWindowViewModel
    {

        #region ----- Variables

        /// <summary>
        /// Main Model with User Interface bindings for static use
        /// </summary>
        public MainWindowModel UserInterfaceModel { get; set; }
        /// <summary>
        /// Sign Model Repository for User Interface bindings of signs
        /// </summary>
        public SignRepository UserInterfaceSigns { get; set; }
        /// <summary>
        /// Agent Model Repository for User Interface bindings of agents
        /// </summary>
        public AgentRepository UserInterfaceAgents { get; set; }
        /// <summary>
        /// Position Model Repository for User Interface bindings of positions
        /// </summary>
        public PositionRepository UserInterfacePositions { get; set; }
        /// <summary>
        /// Edge Model Repository for User Interface bindings of edges
        /// </summary>
        public EdgeRepository UserInterfaceEdges { get; set; }

        /// <summary>
        /// Update timer for User Interface update
        /// </summary>
        private DispatcherTimer GuiUpdateTimer = new DispatcherTimer();

        /// <summary>
        /// Repository of used Map from DataBridge
        /// </summary>
        private IMapRepository UserInterfaceMap;
        /// <summary>
        /// Repository of used Edges from DataBridge
        /// </summary>
        private IEdgeRepository Edges;
        /// <summary>
        /// Repository of used Agents from DataBridge
        /// </summary>
        private IAgentRepository Agents;
        /// <summary>
        /// Repository of used Positions from DataBridge
        /// </summary>
        private IPositionRepository Positions;
        /// <summary>
        /// Repository of used Signs from DataBridge
        /// </summary>
        private IRuleRepository Signs;

        private IEnumerable<Edge> edges;
        private IEnumerable<Position> positions;

        #endregion



        #region ----- Constructor

        /// <summary>
        /// Main data context of XAML
        /// </summary>
        public MainWindowViewModel()
        {
            try
            {
                /// Create Models for GUI Communication
                UserInterfaceModel = new MainWindowModel();
                UserInterfaceSigns = new SignRepository();
                UserInterfaceAgents = new AgentRepository();
                UserInterfacePositions = new PositionRepository();
                UserInterfaceEdges = new EdgeRepository();

                /// Get object repositorys
                UserInterfaceMap = MapRepositoryFactory.CreateRepository();
                Edges = EdgeRepositoryFactory.CreateRepository();
                Agents = AgentRepositoryFactory.CreateRepository();
                Positions = PositionRepositoryFactory.CreateRepository();
                Signs = RuleRepositoryFactory.CreateRepository();
                
                /// Update the map picture only at startup
                Map BackgroundMap = UserInterfaceMap.GetMap();                
                UserInterfaceModel.SetBackgroundInformation(BackgroundMap.BackgroundImageBase64, BackgroundMap.Width, BackgroundMap.Height);

                /// Load Positions and edges once from the DataBridge
                edges = Edges.GetAll();
                positions = Positions.GetAll();
                
                /// Configurate and start the update timer for the gui update
                GuiUpdateTimer.Interval = TimeSpan.FromMilliseconds(10);
                GuiUpdateTimer.Tick += Timer_Tick;
                GuiUpdateTimer.Start();

                /// Bind the command field to the function
                ChangeNetView = new Command(() => ChangeNetViewExecute());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion



        #region ----- Commands

        public Command ChangeNetView { get; }
        /// <summary>
        /// Event that gets executed from the gui and toggles the NetEnabled bit and deletes all Positions and Edges after a certain time
        /// This function is in order to show/hide the lines and positions on that the cars are driving
        /// </summary>
        private void ChangeNetViewExecute()
        {
            UserInterfaceModel.NetEnabled ^= true;

            System.Threading.Thread.Sleep(30);

            UserInterfacePositions.MapPositions.Clear();
            UserInterfaceEdges.MapEdges.Clear();
        }

        #endregion



        #region ----- Events

        /// <summary>
        /// Dispatched Timer update function which gets called in a certain interval
        /// Updates the components of the User Interface
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e">not used</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            /// Temporary storage of the new calculated image scaling for all User Interface components
            double calculatedResizeWidth = 1;
            double calculatedResizeHeight = 1;

            try
            {
                /// Load Agents and signs
                IEnumerable<Agent> agents = Agents.GetAllAgents();
                IEnumerable<Rule> signs = Signs.GetAllRules();
                
                /// Calculate the resize factor of the GUI for scaling
                UserInterfaceModel.GetImageFactor(out calculatedResizeWidth, out calculatedResizeHeight);

                if (UserInterfaceModel.NetEnabled)
                {
                    /// Draw the Position points on the screen
                    UserInterfacePositions.SetScaleFactors(calculatedResizeWidth, calculatedResizeHeight);
                    UserInterfacePositions.DrawPositions(positions);

                    /// Draw the Edge lines on the screen
                    UserInterfaceEdges.SetScaleFactors(calculatedResizeWidth, calculatedResizeHeight);
                    UserInterfaceEdges.DrawEdges(positions, edges);
                }

                /// Draw the Agent images on the screen
                UserInterfaceAgents.SetScaleFactors(calculatedResizeWidth, calculatedResizeHeight);
                UserInterfaceAgents.DrawAgents(positions, edges, agents);

                /// Draw the Signs on the screen (the dynamic but also the static)
                UserInterfaceSigns.SetScaleFactors(calculatedResizeWidth, calculatedResizeHeight);
                UserInterfaceSigns.DrawSigns(signs);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

       

        #endregion

    } // Class
} // Namespace
