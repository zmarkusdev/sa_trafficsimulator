using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationUserInterface.Models
{
    public class AgentRepository
    {
        public ObservableCollection<AgentModel> MapAgents { get; set; }

        public AgentRepository()
        {
            MapAgents = new ObservableCollection<AgentModel>();
        }
    }
}
