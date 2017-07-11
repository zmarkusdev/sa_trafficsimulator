using System;
using Datamodel;

namespace DataAccessLayer
{
    /// <summary>
    /// IRuleDataAccess
    /// </summary>
    public interface IRuleDataAccess : IDataAccess<Rule> { }

    class RuleDataAccess : AbstractDataAccess<Rule>, IRuleDataAccess
    {
    }
}
