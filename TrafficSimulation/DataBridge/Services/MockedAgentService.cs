using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;

namespace DataBridge.Services
{
    class MockedAgentService : Repositories.IAgentRepository
    {
        public Agent Create(Agent agent)
        {
            Agent newAgent = new Agent();
            newAgent.Id = 123;
            newAgent.Acceleration = agent.Acceleration;
            newAgent.CurrentVelocity = agent.CurrentVelocity;
            newAgent.Deceleration = agent.Deceleration;
            newAgent.MaxVelocity = agent.MaxVelocity;
            newAgent.PositionId = agent.PositionId;
            return newAgent;
        }

        public void Delete(Agent agent)
        {
            return;
        }

        public Agent GetAgent(int agentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Agent> GetAgentsForPositionIds(int positionIds)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Agent> GetAllAgents()
        {
            throw new NotImplementedException();
        }

        public Agent Update(Agent agent)
        {
            throw new NotImplementedException();
        }
    }
}
