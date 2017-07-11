namespace DataAccessLayer
{
    /// <summary>
    /// Factory to decouple IAgentDataAccess Interface from Implementation.
    /// </summary>
    public abstract class AgentDataAccessFactory
    {
        static IAgentDataAccess instance;

        /// <summary>
        /// Creates new Repository if no one exists.
        /// </summary>
        /// <returns>New repository or already existing instance</returns>
        public static IAgentDataAccess CreateRepository()
        {
            if (instance == null)
            {
                instance = new AgentDataAccess();
                instance.LoadfromFile("agent");
            }
            return instance;
        }
    }
}
