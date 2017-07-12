using Amazon.SQS;
using Amazon.SQS.Model;
using System;
using System.Threading.Tasks;

namespace VehicleHandoverLibrary
{

    /// <summary>
    /// Class for sending vehicles to a SQS queue
    /// </summary>
    public class VehicleSender
    {
        // Propeties
        private AmazonSQSClient sqsClient;
        private String sqsUrl;
        private int numberOfSentMessages;

        // Constants
        private const String MESSAGE_GROUP_ID = "01";
        private const int MAX_SENT_MESSAGES = 500;

        /// <summary>
        /// Constructor initializing the SQS
        /// </summary>
        /// <param name="group">Name of the groupt that uses the service</param>
        public VehicleSender(Groups group)
        {
            // Instantiate SQS client
            this.sqsClient = Helper.GetSQSClient();

            // Get URL of the queue we want to add vehicles to
            this.sqsUrl = Group.getUrlForGroup(group);
        }

        /// <summary>
        /// Send a vehicle to the queue
        /// </summary>
        /// <param name="vehicle">Vehicle to send</param>
        public void PushVehicle(Vehicle vehicle)
        {
            Task task = new Task(() => sendMessage(vehicle.toJSON()));
            task.Start();
        }

        /// <summary>
        /// Send a string message to the SQS queue
        /// </summary>
        /// <param name="message">Message in string format</param>
        private void sendMessage(String message)
        {
            var sendMessageRequest = new SendMessageRequest(sqsUrl, message);
            sendMessageRequest.MessageGroupId = MESSAGE_GROUP_ID;
            sendMessageRequest.MessageDeduplicationId = Guid.NewGuid().ToString();
            sqsClient.SendMessage(sendMessageRequest);
            this.numberOfSentMessages++;

            if (this.numberOfSentMessages > MAX_SENT_MESSAGES)
                throw new Exception("Maximum of " + MAX_SENT_MESSAGES + " messages allowed per session!");
        }

    }
}
