using Datamodel;

namespace DataAccessLayer
{
    public interface IRuleDataAccess : IDataAccess<Rule> { }

    class RuleDataAccess : AbstractDataAccess<Rule>, IRuleDataAccess
    {
    }
}
