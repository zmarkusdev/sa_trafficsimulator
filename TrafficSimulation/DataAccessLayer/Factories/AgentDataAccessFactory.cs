namespace DataAccessLayer
{
    // decouple IAgentDataAccess Interface from Implementation
    public abstract class AgentDataAccessFactory
    {
        public static IAgentDataAccess CreateRepository()
        {
            return new AgentDataAccess();
        }
    }
}
