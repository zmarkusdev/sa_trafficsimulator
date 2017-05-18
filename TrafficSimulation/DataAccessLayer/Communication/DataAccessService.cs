using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;
using System.ServiceModel;

namespace DataAccessLayer.Communication
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    class DataAccessService : IDataAccessContract
    {
        private IAgentDataAccess agentDataAccess;

        public DataAccessService()
        {
            agentDataAccess = AgentDataAccessFactory.CreateRepository();
            agentDataAccess.LoadfromFile("agent");
        }
        

        public Agent CreateAgent(Agent agent)
        {
            throw new NotImplementedException();
        }

        public void DeleteAgent(Agent agent)
        {
            throw new NotImplementedException();
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
            return agentDataAccess.ReadAll();
        }

        public Agent UpdateAgent(Agent agent)
        {
            throw new NotImplementedException();
        }
    }
}
