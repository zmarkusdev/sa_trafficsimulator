using Datamodel;
using DataModel.Pipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Controller
{
    class RuleTypeController : AbstractPipeServer
    {
        public RuleTypeController() : base(typeof(RuleType))
        {
        }

        public override void executeCommand(string message)
        {
            throw new NotImplementedException();
        }

        public override void write<T>(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
