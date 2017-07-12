using Amazon.SQS;
using Amazon.SQS.Model;
using System;
using System.Threading.Tasks;

namespace VehicleHandoverLibrary
{

    /// <summary>
    /// Class for receiving vehicles from a SQS queue
    /// </summary>
    public class VehicleReceiver
    {
        // Propeties
        private AmazonSQSClient sqsClient;
        private String sqsUrl;

        /// <summary>
        /// Receive Vehicle event handler
        /// </summary>
        public event EventHandler<VehicleEventArgs> ReceiveEventHandler;

        /// <summary>
        /// Constructor initializing the SQS
        /// </summary>
        /// <param name="group">Name of the groupt that uses the service</param>
        public VehicleReceiver(Groups group)
        {
            // Instantiate SQS client
            this.sqsClient = Helper.GetSQSClient();

            // Get URL of the queue we want to add vehicles to
            this.sqsUrl = Group.getUrlForGroup(group);

            // Start polling
            Task task = new Task(() => startLongPolling());
            task.Start();
        }

        /// <summary>
        /// Start polling the message queue
        /// </summary>
        private void startLongPolling()
        {
            while (true)
            {
                var receiveMessageRequest = new ReceiveMessageRequest(sqsUrl);
                var receiveMessageResponse = sqsClient.ReceiveMessage(receiveMessageRequest);

                foreach (var message in receiveMessageResponse.Messages)
                {
                    // Parse vehicle
                    try
                    {
                        var jsonString = message.Body;
                        Vehicle vehicle = Vehicle.fromJSON(jsonString);
                        RaiseReceiveEvent(vehicle);
                    }
                    catch
                    {
                        Console.WriteLine("Couldn't parse JSON");
                    }

                    // Delete it
                    var deleteMessageRequest = new DeleteMessageRequest(sqsUrl, message.ReceiptHandle);
                    sqsClient.DeleteMessage(deleteMessageRequest);
                }
            }
        }

        /// <summary>
        /// Wrap event invocations inside a protected virtual method
        /// to allow derived classes to override the event invocation behavior
        /// </summary>
        /// <param name="vehicle"></param> 
        protected virtual void RaiseReceiveEvent(Vehicle vehicle)
        {
            VehicleEventArgs vehicleEventArgs = new VehicleEventArgs(vehicle);
            this.ReceiveEventHandler?.Invoke(this, vehicleEventArgs);
        }

    }
}
