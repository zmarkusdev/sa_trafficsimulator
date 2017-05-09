using DataAccessLayer.Services;
using DataModel.Pipe;
using NamedPipeWrapper;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Text;

namespace DataAccessLayer.Controller
{
    public class PipeServer
    {
        private IPipeService service;
        private NamedPipeServer<PipeDTO> _pipeServer;

        public PipeServer(string pipeName, IPipeService service)
        {
            this.service = service;
            _pipeServer = new NamedPipeServer<PipeDTO>(pipeName);

            _pipeServer.ClientConnected += delegate (NamedPipeConnection<PipeDTO, PipeDTO> conn)
            {
                Debug.WriteLine("Client {0} is now connected!", conn.Id);
                conn.PushMessage(new PipeDTO(new Guid(), PipeCommand.CREATE, "Welcome"));
            };

            _pipeServer.ClientMessage += delegate (NamedPipeConnection<PipeDTO, PipeDTO> conn, PipeDTO dto)
             {
                 Debug.WriteLine("Client {0} says: {1}", conn.Id, dto.ToString());
             };

            _pipeServer.Start();
        }

        public void write(PipeDTO dto)
        {
            _pipeServer.PushMessage(dto);
        }



            /*
            private static int bufferSize = 4096;
            private NamedPipeServerStream _pipeServer;
            private StreamReader reader;
            private StreamWriter writer;
            private IPipeService service;

            public PipeServer(string pipeName, IPipeService service)
            {
                this.service = service;
                _pipeServer = new NamedPipeServerStream(pipeName, PipeDirection.InOut, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous, 4096, 4096);
                _pipeServer.WaitForConnection();
                reader = new StreamReader(_pipeServer, Encoding.UTF8);
                writer = new StreamWriter(_pipeServer, Encoding.UTF8);
                writer.AutoFlush = true;
                beginRead();
            }

            private void beginRead()
            {
                try
                {
                    StringBuilder sb = new StringBuilder();


                    do
                    {
                        var line = reader.ReadLine();
                    } while (_pipeServer.IsMessageComplete);

                    write(JsonConvert.DeserializeObject<PipeDTO>(sb.ToString()));
                    /*
                    using (StreamReader sr = new StreamReader(_pipeServer))
                    {
                        // Display the read text to the console
                        string temp;
                        while ((temp = sr.ReadLine()) != null)
                        {
                            Console.WriteLine("Received from server: {0}", temp);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    throw;
                }
            }

            public void write(PipeDTO dto)
            {
                writer.Write(JsonConvert.SerializeObject(dto));

                _pipeServer.WaitForPipeDrain();

                beginRead();
            }
    */
        }

}
