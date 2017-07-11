namespace DataAccessLayer
{
    /// <summary>
    /// decouple IRuleDataAccess Interface from Implementation
    /// </summary>
    public class RuleDataAccessFactory
    {
        static IRuleDataAccess instance;

        /// <summary>
        /// Creates new Repository if no one exists.
        /// </summary>
        /// <returns>New repository or already existing instance</returns>
        public static IRuleDataAccess CreateRepository()
        {
            if (instance == null)
            {
                instance = new RuleDataAccess();
                instance.LoadfromFile("rule");
            }
            return instance;
        }
    }
}
