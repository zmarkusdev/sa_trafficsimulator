using Repositories;
using SimulationUserInterface.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationUserInterface.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowModel UserInterfaceModel { get; set; }
        public SignRepository UserInterfaceSigns { get; set; }
        public AgentRepository UserInterfaceAgents { get; set; }




        public MainWindowViewModel()
        {
            try
            {
                UserInterfaceModel = new MainWindowModel();
                UserInterfaceSigns = new SignRepository();
                UserInterfaceAgents = new AgentRepository();

                IMapRepository UserInterfaceMap = MapRepositoryFactory.CreateRepository();
                Datamodel.Map BackgroundMap = UserInterfaceMap.GetMap();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
