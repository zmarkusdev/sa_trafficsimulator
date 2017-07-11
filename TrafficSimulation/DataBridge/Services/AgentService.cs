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
    /// <summary>
    /// Implementation of the IAgentRepository.
    /// </summary>
    public class AgentService : IAgentRepository
    {
        /// <summary>
        /// Creates new Agent
        /// </summary>
        /// <param name="agent">Agent to create</param>
        /// <returns>Created Agent</returns>
        public Agent Create(Agent agent)
        {
            return DataAccessClient.Instance.Channel.CreateAgent(agent);
        }

        /// <summary>
        /// Deletes given agent.
        /// </summary>
        /// <param name="agent">Agent to delete</param>
        public void Delete(Agent agent)
        {
            DataAccessClient.Instance.Channel.DeleteAgent(agent);
        }

        /// <summary>
        /// Get agent by Id.
        /// </summary>
        /// <param name="agentId">Id of agent</param>
        /// <returns>Agent or null</returns>
        public Agent GetAgent(int agentId)
        {
            return DataAccessClient.Instance.Channel.GetAgent(agentId);
        }

        /// <summary>
        /// Get agents by position id.
        /// </summary>
        /// <param name="positionIds">Id of position</param>
        /// <returns>List of agents or null</returns>
        public IEnumerable<Agent> GetAgentsForPositionIds(int positionIds)
        {
            return DataAccessClient.Instance.Channel.GetAgentsForPositionIds(positionIds);
        }

        /// <summary>
        /// Get all agents.
        /// </summary>
        /// <returns>List of agent or null</returns>
        public IEnumerable<Agent> GetAllAgents()
        {

            return DataAccessClient.Instance.Channel.GetAllAgents();
        }

        /// <summary>
        /// Update agent.
        /// </summary>
        /// <param name="agent">Agent to update</param>
        /// <returns>Updated agent</returns>
        public Agent Update(Agent agent)
        {
            return DataAccessClient.Instance.Channel.UpdateAgent(agent);
        }

        /// <summary>
        /// Updates a list of agents.
        /// </summary>
        /// <param name="agents">List of agents to update</param>
        public void BulkUpdate(IEnumerable<Agent> agents)
        {
            DataAccessClient.Instance.Channel.BulkUpdate(agents);
        }
    }
}
