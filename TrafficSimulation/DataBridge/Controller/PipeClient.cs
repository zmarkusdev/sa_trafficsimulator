using DataBridge.Services;
using DataModel.Pipe;
using NamedPipeWrapper;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Text;

namespace DataBridge.Controller
{
    public class PipeClient
    {
        private NamedPipeClient<PipeDTO> _pipeClient;

        public PipeClient(string pipeName)
        {
            _pipeClient = new NamedPipeClient<PipeDTO>(pipeName);

            _pipeClient.ServerMessage += delegate (NamedPipeConnection<PipeDTO, PipeDTO> conn, PipeDTO dto)
             {
                 Debug.WriteLine("Server says: {0}", dto.ToString());
             };

            _pipeClient.Start();
        }

        public void write(PipeDTO dto)
        {
            _pipeClient.PushMessage(dto);
        }




            /*
            public NamedPipeClientStream _pipeClient;
            private StreamReader reader;
            private StreamWriter writer;

            public PipeClient(string pipeName)
            {
                _pipeClient = new NamedPipeClientStream(".", pipeName, PipeDirection.InOut, PipeOptions.Asynchronous);
                _pipeClient.Connect();
                reader = new StreamReader(_pipeClient, Encoding.UTF8);
                writer = new StreamWriter(_pipeClient, Encoding.UTF8);
                writer.AutoFlush = true;
            }

            public PipeDTO writeQueryWithReturnValue(PipeDTO dto)
            {
                string message = JsonConvert.SerializeObject(dto);
                writer.Write(message);

                _pipeClient.WaitForPipeDrain();

                string received;

                do
                {
                    received = reader.ReadLine();
                } while (received == null);



                return JsonConvert.DeserializeObject<PipeDTO>(received);
            }
            */
        }
}