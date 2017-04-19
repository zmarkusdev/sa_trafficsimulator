using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;
using Repositories;
using System.Threading;

namespace AgentSim
{
    /// <summary>
    /// Implementation for the IAgentSim interface for spawning agents and calling their Behaviours
    /// </summary>
    public class AgentSimulation : IAgentSim
    {
        private readonly IAgentSimConfigurationRepository agentSimConfigurationRepository_;

        private bool shouldStop_;
        private Thread simulationThread_;

        /// <summary>
        /// Dependency constructor for the AgentSim class.
        /// </summary>
        /// <param name="agentSimConfigurationRepository">DataBridge dependency of the IAgentSimConfigurationRepository</param>
        public AgentSimulation(IAgentSimConfigurationRepository agentSimConfigurationRepository)
        {
            agentSimConfigurationRepository_ = agentSimConfigurationRepository;

            shouldStop_ = false;
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
            shouldStop_ = false;

            simulationThread_ = new Thread(this.Run);
            simulationThread_.Start();
        }

        /// <summary>
        /// Stops the agent simulation thread
        /// </summary>
        public void Stop()
        {
            shouldStop_ = true;
        }

        /// <summary>
        /// Run method for the simulation thread
        /// </summary>
        private void Run()
        {
            while(!shouldStop_)
            {
                Console.WriteLine("Executing simulation thread cycle");

                Thread.Sleep(100);
            }
        }
    }
}
