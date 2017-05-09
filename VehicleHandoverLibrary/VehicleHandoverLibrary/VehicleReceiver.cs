using Amazon.SQS;
using Amazon.SQS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleHandoverLibrary
{
    public class VehicleReceiver
    {
        // Propeties
        private AmazonSQSClient sqsClient;
        private String sqsUrl;

        // Events
        public event EventHandler<VehicleEventArgs> ReceiveEventHandler;

        // Constructor
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
                    catch (Exception e)
                    {
                        Console.WriteLine("Couldn't parse JSON");
                    }

                    // Delete it
                    var deleteMessageRequest = new DeleteMessageRequest(sqsUrl, message.ReceiptHandle);
                    sqsClient.DeleteMessage(deleteMessageRequest);
                }
            }
        }

        // Wrap event invocations inside a protected virtual method
        // to allow derived classes to override the event invocation behavior
        protected virtual void RaiseReceiveEvent(Vehicle vehicle)
        {
            VehicleEventArgs vehicleEventArgs = new VehicleEventArgs(vehicle);
            this.ReceiveEventHandler?.Invoke(this, vehicleEventArgs);
        }

    }
}
