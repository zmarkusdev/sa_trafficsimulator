using Amazon.SQS;
using Amazon.SQS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleDeactivatorLibrary
{

    /// <summary>
    /// This class receives messages from the Amazon Service to change the state of an agent
    /// The purpose of this class is to tell the simulation that a vehicle 
    /// has been damaged in the UI
    /// </summary>
    public class MessageReceiver
    {
        // Propeties
        private AmazonSQSClient sqsClient;        

        // Events
        /// <summary>
        /// Receive a Message Event Handler
        /// </summary>
        public event EventHandler<MessageEventArgs> ReceiveEventHandler;
        private String SQS_URL;

        /// <summary>
        /// Default constructor requesting the SQS client and url
        /// </summary>
        public MessageReceiver()
        {
            // Instantiate SQS client
            this.sqsClient = Helper.GetSQSClient();
            this.SQS_URL = Helper.GetSQSUrl();

            // Start polling
            Task task = new Task(() => startLongPolling());
            task.Start();
        }

        private void startLongPolling()
        {
            while (true)
            {
                var receiveMessageRequest = new ReceiveMessageRequest(SQS_URL);
                var receiveMessageResponse = sqsClient.ReceiveMessage(receiveMessageRequest);

                foreach (var message in receiveMessageResponse.Messages)
                {
                    // Parse message
                    try
                    {
                        var jsonString = message.Body;
                        Message myMessage = Message.fromJSON(jsonString);
                        RaiseReceiveEvent(myMessage);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Couldn't parse JSON");
                    }

                    // Delete it
                    var deleteMessageRequest = new DeleteMessageRequest(SQS_URL, message.ReceiptHandle);
                    sqsClient.DeleteMessage(deleteMessageRequest);
                }
            }
        }

        /// <summary>
        /// Wrap event invocations inside a protected virtual method
        /// to allow derived classes to override the event invocation behavior
        /// </summary>
        /// <param name="message"></param>
        protected virtual void RaiseReceiveEvent(Message message)
        {
            MessageEventArgs vehicleEventArgs = new MessageEventArgs(message);
            this.ReceiveEventHandler?.Invoke(this, vehicleEventArgs);
        }
    }
}
