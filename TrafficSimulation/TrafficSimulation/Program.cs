using AgentSim;
using AgentSpawner;
using DataManager;
using PhysicEngine;
using System;
using Watchdog;

namespace TrafficSimulation
{
    /// <summary>
    /// Class containing the main entry point into the traffic simulation application.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main entry point into the simulation, starts the watchdog and simulation.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Start applications
            ApplicationWatchdog watchDog = new ApplicationWatchdog();
            watchDog.StartApplicationsSynchronous();
            watchDog.StartWatchThread();

            // Initialize data manager
            IDataManager dataManager = SimDataManager.Instance;
            dataManager.Initialize();
            dataManager.Start();

            // Start physic engine
            var log = new Log();
            IPhysicEngine physicEngine = new SimPhysicEngine(dataManager, log);
            physicEngine.Start();

            // Start agent simulation
            IAgentSim agentSim = new AgentSimulation(dataManager);
            agentSim.Start();

            // Start agent spawner
            IAgentSpawner agentSpawner = new SimAgentSpawner(dataManager);
            agentSpawner.Start();

            // Prepare ending of the simulation
            do
            {
                Console.WriteLine("Press q to quit...");
            } while (!Console.ReadLine().Equals("q"));

            // Stop applications
            agentSpawner.Stop();
            agentSim.Stop();
            physicEngine.Stop();
            dataManager.Stop();
            watchDog.StopWatchThread();
        }
    }
}
