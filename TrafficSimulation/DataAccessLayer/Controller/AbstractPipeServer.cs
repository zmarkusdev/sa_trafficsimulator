using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Controller
{
    public abstract class AbstractPipeServer
    {
        protected static int bufferSize = 10;
        protected JsonStreamConverter converter;
        protected NamedPipeServerStream _pipeServer;
        protected StringBuilder messageBuilder;
        protected byte[] messageBuffer;
        protected string messageChunk;
        protected Type entityClass;

        public AbstractPipeServer(Type clazz)
        {
            this.entityClass = clazz;
            this.converter = JsonStreamConverter.getInstance();
            this.messageBuilder = new StringBuilder();
            this.messageChunk = string.Empty;
        }


        /// <summary>
        /// Creates a new NamedPipeServerStream 
        /// </summary>
        protected void createPipeAndRun(String pipeName)
        {
           this._pipeServer = new NamedPipeServerStream(
               pipeName, PipeDirection.InOut, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous
               );
            run();
        }

        /// <summary>
        /// This method begins an asynchronous operation to wait for a client to connect.
        /// </summary>
        private void run()
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

            beginRead(new Info());
        }

        private void beginRead(Info info)
        {
            try
            {
                _pipeServer.BeginRead(info.Buffer, 0, bufferSize, EndReadCallBack, info);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// This callback is called when the BeginRead operation is completed.
        /// We can arrive here whether the connection is valid or not
        /// </summary>
        private void EndReadCallBack(IAsyncResult result)
        {
            var readBytes = _pipeServer.EndRead(result);
            if (readBytes > 0)
            {
                var info = (Info)result.AsyncState;

                // Get the read bytes and append them
                info.StringBuilder.Append(Encoding.UTF8.GetString(info.Buffer, 0, readBytes));

                if (!_pipeServer.IsMessageComplete) // Message is not complete, continue reading
                {
                    beginRead(info);
                }
                else // Message is completed
                {
                    // Finalize the received string and fire MessageReceivedEvent
                    executeCommand(info.StringBuilder.ToString().TrimEnd('\0'));
                    // Begin a new reading operation
                    beginRead(new Info());
                }
            }
            else // When no bytes were read, it can mean that the client have been disconnected
            {
                try
                {
                    if (_pipeServer.IsConnected)
                    {
                        _pipeServer.Disconnect();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    throw;
                }
                finally
                {
                    _pipeServer.Close();
                    _pipeServer.Dispose();
                }
            }
        }

        public abstract void executeCommand(string message);

        public abstract void write<clazz>(clazz obj);

        protected class Info
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
