using Amazon.SQS;
using Amazon.SQS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleHandoverLibrary
{
    public class VehicleSender
    {
        // Propeties
        private AmazonSQSClient sqsClient;
        private String sqsUrl;
        private int numberOfSentMessages;

        // Constants
        private const String MESSAGE_GROUP_ID = "01";
        private const int MAX_SENT_MESSAGES = 500;

        // Constructor
        public VehicleSender(Groups group)
        {
            // Instantiate SQS client
            this.sqsClient = Helper.GetSQSClient();

            // Get URL of the queue we want to add vehicles to
            this.sqsUrl = Group.getUrlForGroup(group);
        }

        public void PushVehicle(Vehicle vehicle)
        {
            Task task = new Task(() => sendMessage(vehicle.toJSON()));
            task.Start();
        }

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
