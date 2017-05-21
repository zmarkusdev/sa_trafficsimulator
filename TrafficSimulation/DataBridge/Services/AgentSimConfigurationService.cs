using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;
using DataBridge.Communication;

namespace DataBridge.Services
{
    class AgentSimConfigurationService : IAgentSimConfigurationRepository
    {
        public IEnumerable<AgentSimConfiguration> GetAll()
        {
            return DataAccessClient.Instance.Channel.GetAllAgentSimConfigurations();
        }
    }
}
