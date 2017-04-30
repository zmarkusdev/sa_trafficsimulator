using Datamodel;

namespace DataAccessLayer
{
    public abstract class AgentDataAccessFactory
    {
        public static AbstractDataAccess<Agent> CreateRepository()
        {
            return new AgentDataAccess();
        }
    }
}
