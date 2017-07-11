using Datamodel;

namespace DataAccessLayer
{
    /// <summary>
    /// IAgentDataAccess
    /// </summary>
    public interface IAgentDataAccess : IDataAccess<Agent> { }

    class AgentDataAccess : AbstractDataAccess<Agent>, IAgentDataAccess
    {
    }
}
