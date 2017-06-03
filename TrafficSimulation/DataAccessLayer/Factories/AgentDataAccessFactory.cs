namespace DataAccessLayer
{
    // decouple IAgentDataAccess Interface from Implementation
    public abstract class AgentDataAccessFactory
    {
        static IAgentDataAccess instance;

        public static IAgentDataAccess CreateRepository()
        {
            if (instance == null)
                instance = new AgentDataAccess();
            return instance;
        }
    }
}
