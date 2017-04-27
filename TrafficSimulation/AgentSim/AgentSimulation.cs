using DataManager;
using System;
using System.Threading;

namespace AgentSim
{
    /// <summary>
    /// Implementation for the IAgentSim interface for spawning agents and calling their Behaviours
    /// </summary>
    public class AgentSimulation : IAgentSim
    {
        private bool shouldStop_;
        private Thread simulationThread_;

        private readonly IDataManager dataManager_;

        /// <summary>
        /// Dependency constructor for the AgentSim class.
        /// </summary>
        public AgentSimulation(IDataManager dataManager)
        {
            shouldStop_ = false;
            dataManager_ = dataManager;
        }

        /// <summary>
        /// Starts the agent simulation thread
        /// </summary>
        public void Start()
        {
            shouldStop_ = false;

            simulationThread_ = new Thread(Run);
            simulationThread_.Start();
        }

        /// <summary>
        /// Stops the agent simulation thread
        /// </summary>
        public void Stop()
        {
            shouldStop_ = true;
            // Wait until simulation thread is terminated
            while (simulationThread_.IsAlive) Thread.Sleep(100);
        }

        /// <summary>
        /// Run method for the simulation thread
        /// </summary>
        private void Run()
        {
            while(!shouldStop_)
            {
                //Console.WriteLine("Executing simulation thread cycle");
                
                // TODO

                Thread.Sleep(100);
            }
        }
    }
}
