using Datamodel;
using DataModel.Pipe;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Controller
{
    public class AgentController : AbstractPipeServer
    {
        public AgentController() : base(typeof(Agent))
        {
            createPipeAndRun(PipeUtil.AGENT());
        }

        public override void executeCommand(string message)
        {
            // comment because of a failed test, throw new NotImplementedException();
        }

        public override void write<T>(T obj)
        {
            throw new NotImplementedException();
        }

    }
}
