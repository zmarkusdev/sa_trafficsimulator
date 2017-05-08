using DataAccessLayer.Controller;
using DataBridge.Services;
using DataModel.Pipe;
using System;
using System.IO;
using System.IO.Pipes;
using System.Text;

namespace DataBridge.Controller
{
    public class PipeClient
    {
        protected JsonStreamConverter converter;
        private NamedPipeClientStream _pipeClient;
        private StreamReader reader;
        private StreamWriter writer;

        public PipeClient(string pipeName)
        {
            _pipeClient = new NamedPipeClientStream(pipeName);
            _pipeClient.Connect();
            this.converter = JsonStreamConverter.getInstance();
            reader = new StreamReader(_pipeClient);
            writer = new StreamWriter(_pipeClient);
        }

        public PipeDTO writeQueryWithReturnValue(PipeDTO dto)
        {
            writer.Write(converter.convertToJson<PipeDTO>(dto));
            writer.Flush();

            return converter.convertFromJson<PipeDTO>(reader.ReadToEnd());
        }
    }
}