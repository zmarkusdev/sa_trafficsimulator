using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;
using Repositories;

namespace AgentSim
{
    /// <summary>
    /// Implementation for the IAgentSim interface for spawning agents and calling their Behaviours
    /// </summary>
    public class AgentSim : IAgentSim
    {
        private readonly IAgentSimConfigurationRepository agentSimConfigurationRepository_;

        /// <summary>
        /// Dependency constructor for the AgentSim class.
        /// </summary>
        /// <param name="agentSimConfigurationRepository">DataBridge dependency of the IAgentSimConfigurationRepository</param>
        public AgentSim(IAgentSimConfigurationRepository agentSimConfigurationRepository)
        {
            agentSimConfigurationRepository_ = agentSimConfigurationRepository;
        }

        /// <summary>
        /// Spawns a new agent in the agent simulation
        /// </summary>
        /// <param name="agent">Agent object containing the data for the new agent</param>
        public void SpawnAgent(Agent agent)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Starts the agent simulation thread
        /// </summary>
        public void Start()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stops the agent simulation thread
        /// </summary>
        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
