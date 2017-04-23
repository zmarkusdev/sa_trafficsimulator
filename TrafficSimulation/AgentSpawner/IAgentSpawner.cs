using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSpawner
{
    /// <summary>
    /// Agent spawner interface responsible for spawning new agents in the simulation
    /// </summary>
    public interface IAgentSpawner
    {
        /// <summary>
        /// Starts the agent spawner thread
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the agent spawner thread
        /// </summary>
        void Stop();
    }
}
