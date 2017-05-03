using Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RuleDataAccessFactory
    {
            public static IRuleDataAccess CreateRepository()
            {
                return new RuleDataAccess();
            }
    }
}
