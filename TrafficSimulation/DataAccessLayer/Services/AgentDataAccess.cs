using Datamodel;

namespace DataAccessLayer
{
    public interface IAgentDataAccess : IDataAccess<Agent> { }

    class AgentDataAccess : AbstractDataAccess<Agent>, IAgentDataAccess
    {
    }
}
