using Datamodel;
using DataModel.Pipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Controller
{
    class AgentTypeController : AbstractPipeServer
    {
        public AgentTypeController() : base(typeof(AgentType))
        {
            createPipeAndRun(PipeUtil.AGENT_TYPE());
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
