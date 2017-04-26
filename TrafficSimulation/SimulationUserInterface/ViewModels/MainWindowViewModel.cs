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

        private DispatcherTimer timer = new DispatcherTimer();

        private IEdgeRepository Edges;
        private IAgentRepository Agents;

        public MainWindowViewModel()
        {
            try
            {
                UserInterfaceModel = new MainWindowModel();
                UserInterfaceSigns = new SignRepository();
                UserInterfaceAgents = new AgentRepository();

                IMapRepository UserInterfaceMap = MapRepositoryFactory.CreateRepository();
                Datamodel.Map BackgroundMap = UserInterfaceMap.GetMap();
                UserInterfaceModel.SetBackgroundInformation(BackgroundMap.BackgroundImageBase64, BackgroundMap.Width, BackgroundMap.Height);

                Edges = EdgeRepositoryFactory.CreateRepository();
                Agents = AgentRepositoryFactory.CreateRepository();


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

                IEnumerable<Datamodel.Edge> Eds = Edges.GetAll();
                IEnumerable<Datamodel.Agent> Ags = Agents.GetAllAgents();

                UserInterfaceAgents.MapAgents.Clear();

                UserInterfaceAgents.MapAgents.Add(new AgentModel(0, 0, 0, 0, 50, 100));
                UserInterfaceAgents.MapAgents.Add(new AgentModel(0, 0, -90, 0, 50, 100));

                double tempResizeWidth, tempResizeHeight;

                UserInterfaceModel.GetImageFactor(out tempResizeWidth, out tempResizeHeight);

                UserInterfaceAgents.ApplyImageResize(tempResizeWidth, tempResizeHeight);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
