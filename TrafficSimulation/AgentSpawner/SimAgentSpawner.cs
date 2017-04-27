using DataManager;
using DataManager.MappingModels;
using System;
using System.Linq;
using System.Threading;

namespace AgentSpawner
{
    /// <summary>
    /// Agent spawner implementation responsible for spawning new agents in the simulation
    /// </summary>
    public class SimAgentSpawner : IAgentSpawner
    {
        private bool shouldStop_;
        private Thread spawnerThread_;

        private readonly IDataManager dataManager_;

        /// <summary>
        /// Dependency constructor getting the datamanager instance for fetching the data
        /// from the data access components
        /// </summary>
        /// <param name="dataManager"></param>
        public SimAgentSpawner(IDataManager dataManager)
        {
            dataManager_ = dataManager;
        }

        /// <summary>
        /// Starts the agent spawner thread
        /// </summary>
        public void Start()
        {
            shouldStop_ = false;

            spawnerThread_ = new Thread(Run);
            spawnerThread_.Start();
        }

        /// <summary>
        /// Stops the agent spawner thread
        /// </summary>
        public void Stop()
        {
            shouldStop_ = true;
            //Wait until spawner thread is terminated
            while (spawnerThread_.IsAlive) Thread.Sleep(100);
        }

        private void Run()
        {
            // Prepare random generator
            Random rnd = new Random();

            while (!shouldStop_)
            {
                // Get agent sim configurations
                var configurations = dataManager_.AgentSimConfigurations;

                // Get start positions
                var startPositions = dataManager_.StartPositions;

                // Get start edges
                var startEdges = dataManager_.Edges.Where(e => 
                    startPositions.SelectMany(p => p.SuccessorEdgeIds).Any(successorEdgeId => successorEdgeId == e.Id)).ToArray();

                if(startEdges.Any())
                { 
                    // Iterate over configurations
                    foreach(var configuration in configurations)
                    {
                        // Roll probability for spawn for current configuration
                        if(rnd.Next(0, 100) <= configuration.SpawnPropability)
                        {
                            // Roll a start edge
                            var startEdge = startEdges[rnd.Next(0, startEdges.Count() - 1)];

                            // Agent should be spawned, prepare new agent
                            var agent = new SimAgent
                            {
                                CurrentVelocity = 0,
                                EdgeId = startEdge.Id,
                                RunLength = 0,
                                RunLengthExact = 0,
                                CurrentAccelerationExact = 0,
                                CurrentVelocityExact = 0,
                                // Roll the maximum allowed acceleration
                                Acceleration = rnd.Next(configuration.Acceleration - configuration.AccelerationSpread, configuration.Acceleration + configuration.AccelerationSpread),
                                // Roll the maximum allowed deceleration
                                Deceleration = rnd.Next(configuration.Deceleration - configuration.DecelerationSpread, configuration.Deceleration + configuration.DecelerationSpread),
                                // Roll the maximum allowed velocity
                                MaxVelocity = rnd.Next(configuration.Velocity - configuration.VelocitySpread, configuration.Velocity + configuration.VelocitySpread),
                                // Roll vehicle length
                                VehicleLength = rnd.Next(configuration.VehicleLength - configuration.VehicleLengthSpread, configuration.VehicleLength + configuration.VehicleLengthSpread)
                            };

                            // Check collisions on the start edge and dont spawn agent on collision (just skip this agent)
                            if(!dataManager_.GetAgentsInRange(startEdge.Id, 0, agent.VehicleLength).Any())
                            {
                                // Set agent starting position to it's vehicle length
                                agent.RunLength = agent.VehicleLength;
                                dataManager_.CreateAgent(agent);
                            }
                        }
                    }
                }

                // Wait for 2 seconds before next run
                Thread.Sleep(2000);
            }
        }
    }
}
