namespace DataAccessLayer
{
    // decouple IRuleDataAccess Interface from Implementation
    public class RuleDataAccessFactory
    {
            public static IRuleDataAccess CreateRepository()
            {
                return new RuleDataAccess();
            }
    }
}
