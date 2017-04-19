using Datamodel;
using System.Threading.Tasks;

namespace AgentSim.Behaviours
{
    /// <summary>
    /// Agent behaviour implements the decision making for the agents
    /// </summary>
    internal interface IBehaviour
    {
        /// <summary>
        /// Execute decision making for the given agent synchronously
        /// </summary>
        /// <param name="agent">Agent for which the decision making should be executed</param>
        void ExecuteDecisionMaking(Agent agent);

        /// <summary>
        /// Execute decision making for the given agent asynchronously
        /// </summary>
        /// <param name="agent">Agent for which the decision making should be executed</param>
        /// <returns>Async task</returns>
        Task ExecuteDecisionMakingAsync(Agent agent);
    }
}
