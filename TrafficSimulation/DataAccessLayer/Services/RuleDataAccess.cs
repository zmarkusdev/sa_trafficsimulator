using Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Pipe;

namespace DataAccessLayer
{
    class RuleDataAccess : AbstractDataAccess<Rule>
    {
        DataAccessCommon dataAccessCommon = DataAccessCommon.getInstance();

        public override Rule Create(Rule rule)
        {
            if (rule.Id == 0)
                rule.Id = dataAccessCommon.getuniqueId();
            rule = base.Create(rule);

            return (rule);
        }

        public override void executeCommand(PipeDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
