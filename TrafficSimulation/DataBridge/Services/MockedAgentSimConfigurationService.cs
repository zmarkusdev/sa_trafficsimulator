using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;
using Repositories;

namespace DataBridge.Services
{
    class MockedAgentSimConfigurationService : IAgentSimConfigurationRepository
    {
        public IEnumerable<AgentSimConfiguration> GetAll()
        {
            Random rnd = new Random();
            List<AgentSimConfiguration> agentSimConfigs = new List<AgentSimConfiguration>();

            for (int i = 0; i < 10; i++)
            {
                AgentSimConfiguration agentSimConfig = new AgentSimConfiguration();
                agentSimConfig.Acceleration = rnd.Next(500);
                agentSimConfig.AccelerationSpread = rnd.Next(500);
                agentSimConfig.Deceleration = rnd.Next(500);
                agentSimConfig.DecelerationSpread = rnd.Next(500);
                agentSimConfig.SpawnPropability = rnd.Next(500);
                agentSimConfig.Velocity = rnd.Next(500);
                agentSimConfig.VelocitySpread = rnd.Next(500);
                agentSimConfigs.Add(agentSimConfig);
            }

            return agentSimConfigs;
        }
    }
}
