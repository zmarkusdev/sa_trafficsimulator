using DataAccessLayer.Controller;
using DataBridge.Services;
using DataModel.Pipe;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;

namespace DataBridge.Controller
{
    public class PipeClient
    {
        protected static int bufferSize = 10;
        protected JsonStreamConverter converter;
        private NamedPipeClientStream _pipeClient;
        private AbstractService service;

        public PipeClient(string pipeName, AbstractService service)
        {
            _pipeClient = new NamedPipeClientStream(pipeName);
            _pipeClient.Connect();
            this.service = service;
            this.converter = JsonStreamConverter.getInstance();
        }

        public void writeQueryWithReturnValue(PipeDTO dto)
        {
            _pipeClient.BeginWrite(
                Encoding.UTF8.GetBytes(converter.convertToJson<PipeDTO>(dto)),
                0,
                Encoding.UTF8.GetBytes(converter.convertToJson<PipeDTO>(dto)).Length,
                EndWriteCallBack,
                _pipeClient
            );

            beginRead(new Info());
        }

        private void EndWriteCallBack(IAsyncResult result)
        {
            try
            {
                // End the write
                _pipeClient.EndWrite(result);
                _pipeClient.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void beginRead(Info info)
        {
            try
            {
                _pipeClient.BeginRead(info.Buffer, 0, bufferSize, EndReadCallback, info);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
}

        private void EndReadCallback(IAsyncResult result)
        {
            var readBytes = _pipeClient.EndRead(result);
            if (readBytes > 0)
            {
                var info = (Info)result.AsyncState;

                // Get the read bytes and append them
                info.StringBuilder.Append(Encoding.UTF8.GetString(info.Buffer, 0, readBytes));

                if (!_pipeClient.IsMessageComplete) // Message is not complete, continue reading
                {
                    beginRead(info);
                }
                else // Message is completed
                {
                    // Finalize the received string and fire MessageReceivedEvent
                    service.handleReturnValue(converter.convertFromJson<PipeDTO>(info.StringBuilder.ToString().TrimEnd('\0')));
                    // Begin a new reading operation
                    beginRead(new Info());
                }
            }
            else // When no bytes were read, it can mean that the client have been disconnected
            {
                try
                {
                    if (_pipeClient.IsConnected)
                    {
                        _pipeClient.Close();
                        _pipeClient.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }

        private class Info
        {
            public readonly byte[] Buffer;
            public readonly StringBuilder StringBuilder;

            public Info()
            {
                Buffer = new byte[bufferSize];
                StringBuilder = new StringBuilder();
            }
        }
    }
}