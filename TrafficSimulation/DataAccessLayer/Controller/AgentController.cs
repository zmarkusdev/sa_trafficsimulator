using DataModel.Pipe;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Controller
{
    class AgentController : AbstractPipeServer
    {
        public AgentController() : base()
        {
            createPipe(PipeUtil.AGENT());
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
