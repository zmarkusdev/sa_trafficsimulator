using Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSim.Spawners
{
    /// <summary>
    /// Interface for the agent spawners responsible for spawning new agents.
    /// </summary>
    internal interface ISpawner
    {
        /// <summary>
        /// Spawns agent with the given configurations and returns the agents that were spawned.
        /// There is a probability that no agents will be returned. This method also checks the possible
        /// starting positions for the generated agents if they are empty and places them there.
        /// </summary>
        /// <param name="simConfiguration">Agent sim configuration containing the parameters for generation</param>
        /// <returns>List of spawned agents, may contain no agents.</returns>
        IEnumerable<Agent> SpawnAgents(IEnumerable<AgentSimConfiguration> simConfiguration);
    }
}
