using DataAccessLayer.Services;
using DataModel.Pipe;
using System;
using System.IO;
using System.IO.Pipes;
using System.Text;

namespace DataAccessLayer.Controller
{
    public class PipeServer
    {
        private static int bufferSize = 4096;
        private JsonStreamConverter converter;
        private NamedPipeServerStream _pipeServer;
        private StreamReader reader;
        private StreamWriter writer;
        private IPipeService service;

        public PipeServer(string pipeName, IPipeService service)
        {
            this.converter = JsonStreamConverter.getInstance();
            reader = new StreamReader(_pipeServer);
            writer = new StreamWriter(_pipeServer);
            this.service = service;

            this._pipeServer = new NamedPipeServerStream(pipeName, PipeDirection.InOut, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous);

            connect();
        }


        /// <summary>
        /// This method begins an asynchronous operation to wait for a client to connect.
        /// </summary>
        private void connect()
        {
            try
            {
                _pipeServer.BeginWaitForConnection(WaitForConnectionCallBack, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// This callback is called when the async WaitForConnection operation is completed,
        /// whether a connection was made or not. WaitForConnection can be completed when the server disconnects.
        /// </summary>
        private void WaitForConnectionCallBack(IAsyncResult result)
        {
            // Call EndWaitForConnection to complete the connection operation
            _pipeServer.EndWaitForConnection(result);

            beginRead();
        }

        private void beginRead()
        {
            try
            {
                converter.convertFromJson<PipeDTO>(reader.ReadToEnd());
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
            writer.Write(converter.convertToJson<PipeDTO>(dto));
            writer.Flush();
        }
    }

}
