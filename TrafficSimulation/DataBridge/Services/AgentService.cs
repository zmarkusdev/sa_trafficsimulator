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
    public class AgentService : IAgentRepository
    {
        public Agent Create(Agent agent)
        {
            return DataAccessClient.Instance.Channel.CreateAgent(agent);
        }

        public void Delete(Agent agent)
        {
            DataAccessClient.Instance.Channel.DeleteAgent(agent);
        }

        public Agent GetAgent(int agentId)
        {
            return DataAccessClient.Instance.Channel.GetAgent(agentId);
        }

        public IEnumerable<Agent> GetAgentsForPositionIds(int positionIds)
        {
            return DataAccessClient.Instance.Channel.GetAgentsForPositionIds(positionIds);
        }

        public IEnumerable<Agent> GetAllAgents()
        {

            return DataAccessClient.Instance.Channel.GetAllAgents();
        }

        public Agent Update(Agent agent)
        {
            return DataAccessClient.Instance.Channel.UpdateAgent(agent);
        }

        public void BulkUpdate(IEnumerable<Agent> agents)
        {
            DataAccessClient.Instance.Channel.BulkUpdate(agents);
        }
    }
}
