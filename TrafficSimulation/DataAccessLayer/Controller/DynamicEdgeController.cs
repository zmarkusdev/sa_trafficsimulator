using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Controller
{
    class DynamicEdgeController : AbstractPipeServer
    {
        public void read<T>(T obj)
        {
            throw new NotImplementedException();
        }

        public void run(string pipeName)
        {
            throw new NotImplementedException();
        }

        public void write<T>(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
