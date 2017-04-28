using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Controller
{
    abstract class AbstractPipeServer
    {
        protected JsonStreamConverter converter;
        protected NamedPipeServerStream serverStream;

        public AbstractPipeServer()
        {
            this.converter = JsonStreamConverter.getInstance();
        }

        protected void createPipe(String pipeName)
        {
           this.serverStream = new NamedPipeServerStream(pipeName, PipeDirection.InOut, 1);
        }

        public abstract void run(String pipeName);

        public abstract void write<T>(T obj);

        public abstract void read<T>(T obj);
    }
}
