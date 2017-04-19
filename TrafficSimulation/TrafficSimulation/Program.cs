using AgentSim;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            // Prepare dependencies
            IAgentSimConfigurationRepository agentSimConfigurationRepository = AgentSimConfigurationRepositoryFactory.CreateRepository();

            // Start agent simulation
            IAgentSim agentSim = new AgentSimulation(agentSimConfigurationRepository);
            agentSim.Start();


            // Prepare ending of the simulation
            do
            {
                Console.WriteLine("Press q to quit...");
            } while (!Console.ReadLine().Equals("q"));

            // Stop applications
            agentSim.Stop();
        }
    }
}
