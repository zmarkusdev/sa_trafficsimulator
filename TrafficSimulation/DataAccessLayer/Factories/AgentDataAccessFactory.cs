using Datamodel;

namespace DataAccessLayer
{
    public abstract class AgentDataAccessFactory
    {
        public static IAgentDataAccess CreateRepository()
        {
            return new AgentDataAccess();
        }
    }
}
