using Datamodel;
using DataModel.Pipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Controller
{
    class DynamicEdgeController : AbstractPipeServer
    {
        public DynamicEdgeController() : base(typeof(DynamicEdge))
        {
            createPipeAndRun(PipeUtil.DYNAMIC_EDGE());
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
