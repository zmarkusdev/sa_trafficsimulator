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
                agentSimConfig.Acceleration = rnd.Next(4,8);
                agentSimConfig.AccelerationSpread = rnd.Next(1,3);
                agentSimConfig.Deceleration = rnd.Next(4,8);
                agentSimConfig.DecelerationSpread = rnd.Next(1,3);
                agentSimConfig.SpawnPropability = rnd.Next(1,66);
                agentSimConfig.Velocity = rnd.Next(20,30);
                agentSimConfig.VelocitySpread = rnd.Next(4,8);
                agentSimConfig.VehicleLength = rnd.Next(2, 4);
                agentSimConfig.VehicleLengthSpread = rnd.Next(1, 2);
                agentSimConfigs.Add(agentSimConfig);
            }

            return agentSimConfigs;
        }
    }
}
