using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;
using DataAccessLayer;

namespace DataBridge
{
    class BetterMockedAgentService : IAgentRepository
    {
        IAgentDataAccess agentDataAccess = AgentDataAccessFactory.CreateRepository();

        public BetterMockedAgentService()
        {
            agentDataAccess.LoadfromFile("agent");
        }
        public Agent Create(Agent agent)
        {
            return agentDataAccess.Create(agent);
        }

        public void Delete(Agent agent)
        {
            agentDataAccess.Delete(agent);
        }

        public Agent GetAgent(int agentId)
        {
            return agentDataAccess.ReadbyId(agentId);
        }

        public IEnumerable<Agent> GetAgentsForPositionIds(int positionIds)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Agent> GetAllAgents()
        {
            return agentDataAccess.ReadAll();
        }

        public Agent Update(Agent agent)
        {
            agentDataAccess.Update(agent);
            return agent;
        }
    }
}
