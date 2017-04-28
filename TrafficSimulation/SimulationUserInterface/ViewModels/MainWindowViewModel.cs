using Datamodel;
using Repositories;
using SimulationUserInterface.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SimulationUserInterface.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowModel UserInterfaceModel { get; set; }
        public SignRepository UserInterfaceSigns { get; set; }
        public AgentRepository UserInterfaceAgents { get; set; }
        public PositionRepository UserInterfacePositions { get; set; }
        public EdgeRepository UserInterfaceEdges { get; set; }

        private DispatcherTimer timer = new DispatcherTimer();

        private IEdgeRepository Edges;
        private IAgentRepository Agents;
        private IPositionRepository EdgeEndpointPositions;

        public MainWindowViewModel()
        {
            try
            {
                UserInterfaceModel = new MainWindowModel();
                UserInterfaceSigns = new SignRepository();
                UserInterfaceAgents = new AgentRepository();
                UserInterfacePositions = new PositionRepository();
                UserInterfaceEdges = new EdgeRepository();

                IMapRepository UserInterfaceMap = MapRepositoryFactory.CreateRepository();
                Map BackgroundMap = UserInterfaceMap.GetMap();
                UserInterfaceModel.SetBackgroundInformation(BackgroundMap.BackgroundImageBase64, BackgroundMap.Width, BackgroundMap.Height);

                Edges = EdgeRepositoryFactory.CreateRepository();
                Agents = AgentRepositoryFactory.CreateRepository();
                EdgeEndpointPositions = PositionRepositoryFactory.CreateRepository();


                timer.Interval = TimeSpan.FromMilliseconds(10);
                timer.Tick += Timer_Tick;
                timer.Start();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {

                IEnumerable<Edge> Eds = Edges.GetAll();
                IEnumerable<Agent> Ags = Agents.GetAllAgents();
                IEnumerable<Position> Pos = EdgeEndpointPositions.GetAll();

                UserInterfaceAgents.MapAgents.Clear();

                double tempResizeWidth, tempResizeHeight;

                UserInterfaceModel.GetImageFactor(out tempResizeWidth, out tempResizeHeight);

                UserInterfaceAgents.MapAgents.Add(new AgentModel(100, 300, 0, 0, 50, 100, tempResizeWidth, tempResizeHeight));
                UserInterfaceAgents.MapAgents.Add(new AgentModel(300, 50, -90, 0, 50, 100, tempResizeWidth, tempResizeHeight));

                UserInterfacePositions.SetScaleFactors(tempResizeWidth, tempResizeHeight);
                UserInterfacePositions.DrawPositions(Pos);

                UserInterfaceEdges.SetScaleFactors(tempResizeWidth, tempResizeHeight);
                UserInterfaceEdges.DrawEdges(Pos, Eds);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
