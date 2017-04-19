using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSim.Behaviours
{
    /// <summary>
    /// BehaviourFactory creates the implementation of the IBehaviour interface.
    /// </summary>
    internal static class BehaviourFactory
    {
        /// <summary>
        /// Creates the current version of the agent IBehaviour implementation.
        /// </summary>
        /// <returns>Current valid version of the IBehaviour implementation</returns>
        internal static IBehaviour CreateBehaviour()
        {
            throw new NotImplementedException();
        }
    }
}
