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
        public AgentTypeController() : base()
        {
            createPipe(PipeUtil.AGENT_TYPE());
        }

        public override void read<T>(T obj)
        {
            throw new NotImplementedException();
        }

        public override void run(string pipeName)
        {
            throw new NotImplementedException();
        }

        public override void write<T>(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
