namespace DataAccessLayer
{
    // decouple IRuleDataAccess Interface from Implementation
    public class RuleDataAccessFactory
    {
        static IRuleDataAccess instance;

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
