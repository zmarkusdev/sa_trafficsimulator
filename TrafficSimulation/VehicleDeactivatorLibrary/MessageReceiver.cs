using Amazon.SQS;
using Amazon.SQS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleDeactivatorLibrary
{
    public class MessageReceiver
    {
        // Propeties
        private AmazonSQSClient sqsClient;        

        // Events
        public event EventHandler<MessageEventArgs> ReceiveEventHandler;
        private String SQS_URL;

        // Constructor
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

        // Wrap event invocations inside a protected virtual method
        // to allow derived classes to override the event invocation behavior
        protected virtual void RaiseReceiveEvent(Message message)
        {
            MessageEventArgs vehicleEventArgs = new MessageEventArgs(message);
            this.ReceiveEventHandler?.Invoke(this, vehicleEventArgs);
        }
    }
}
