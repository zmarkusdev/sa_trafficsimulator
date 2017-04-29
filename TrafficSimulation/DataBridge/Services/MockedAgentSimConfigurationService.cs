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
                agentSimConfig.Acceleration = 3 + rnd.Next(4);
                agentSimConfig.AccelerationSpread = rnd.Next(3);
                agentSimConfig.Deceleration = 8 + rnd.Next(4);
                agentSimConfig.DecelerationSpread = rnd.Next(3) - 3;
                agentSimConfig.SpawnPropability = rnd.Next(100);
                agentSimConfig.Velocity = rnd.Next(50);
                agentSimConfig.VelocitySpread = rnd.Next(20) - 20;
                agentSimConfigs.Add(agentSimConfig);
            }

            return agentSimConfigs;
        }
    }
}
