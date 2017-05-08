using System;
using Datamodel;
using DataModel.Pipe;

namespace DataAccessLayer
{
    public interface IRuleDataAccess : IDataAccess<Rule> { }

    class RuleDataAccess : AbstractDataAccess<Rule>, IRuleDataAccess
    {
        public override void executeCommand(PipeDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
