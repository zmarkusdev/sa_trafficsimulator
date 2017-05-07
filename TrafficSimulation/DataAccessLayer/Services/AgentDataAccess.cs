using Datamodel;
using DataModel.Pipe;

namespace DataAccessLayer
{
    public interface IAgentDataAccess : IDataAccess<Agent> { }

    class AgentDataAccess : AbstractDataAccess<Agent>, IAgentDataAccess
    {
    }
}
