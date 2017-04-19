using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;
using Repositories;
using System.Threading;
using AgentSim.Spawners;

namespace AgentSim
{
    /// <summary>
    /// Implementation for the IAgentSim interface for spawning agents and calling their Behaviours
    /// </summary>
    public class AgentSimulation : IAgentSim
    {
        private readonly IAgentSimConfigurationRepository agentSimConfigurationRepository_;
        private readonly IPositionRepository positionRepository_;
        private readonly IAgentRepository agentRepository_;

        private bool shouldStop_;
        private Thread simulationThread_;

        private List<Agent> agents_;

        /// <summary>
        /// Dependency constructor for the AgentSim class.
        /// </summary>
        /// <param name="agentSimConfigurationRepository">DataBridge dependency of the IAgentSimConfigurationRepository</param>
        /// <param name="positionRepository">DataBridge dependency of the IPositionRepository</param>
        public AgentSimulation(IAgentSimConfigurationRepository agentSimConfigurationRepository, IPositionRepository positionRepository, IAgentRepository agentRepository)
        {
            agentSimConfigurationRepository_ = agentSimConfigurationRepository;
            positionRepository_ = positionRepository;
            agentRepository_ = agentRepository;
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
            // Get agent configuration
            IEnumerable<AgentSimConfiguration> agentConfigurations = agentSimConfigurationRepository_.GetAll();

            // Create instance of spawner
            ISpawner spawner = new Spawner(positionRepository_);

            while(!shouldStop_)
            {
                Console.WriteLine("Executing simulation thread cycle");

                // Spawn new agents
                IEnumerable<Agent> newAgents = spawner.SpawnAgents(agentConfigurations);

                // Execute behaviours for all agents

                Thread.Sleep(100);
            }
        }
    }
}
