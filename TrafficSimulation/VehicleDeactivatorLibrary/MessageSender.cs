using Amazon.SQS;
using Amazon.SQS.Model;
using System;
using System.Threading.Tasks;

namespace VehicleDeactivatorLibrary
{

    /// <summary>
    /// This class sends messages to the Amazon Service to deactivate agents
    /// The purpose of this class is to tell the simulation that a vehicle 
    /// has been damaged in the UI
    /// </summary>
    public class MessageSender
    {

        // Propeties
        private AmazonSQSClient sqsClient;
        private int numberOfSentMessages;

        // Constants
        private const String MESSAGE_GROUP_ID = "01";
        private const int MAX_SENT_MESSAGES = 500;
        private String SQS_URL;

        /// <summary>
        /// Default constructor requesting the SQS client and url
        /// </summary>
        public MessageSender()
        {
            // Instantiate SQS client
            this.sqsClient = Helper.GetSQSClient();
            this.SQS_URL = Helper.GetSQSUrl();
        }

        /// <summary>
        /// Create a new task for pushing a message
        /// </summary>
        /// <param name="message">Message to send to the queue</param>
        private void PushMessage(Message message)
        {
            Task task = new Task(() => sendMessage(message.toJSON()));
            task.Start();
        }

        /// <summary>
        /// Function that is called if a agent (vehicle) his state should be changed from
        /// working to not working or vice versa
        /// </summary>
        /// <param name="vehicleId">Id of the vehicle</param>
        public void ToggleVehicle(int vehicleId)
        {
            Message message = new Message();
            message.AgentId = vehicleId;
            PushMessage(message);
        }

        /// <summary>
        /// Send a message to the SQS
        /// </summary>
        /// <param name="message">Message to send</param>
        private void sendMessage(String message)
        {
            var sendMessageRequest = new SendMessageRequest(SQS_URL, message);
            sqsClient.SendMessage(sendMessageRequest);
            this.numberOfSentMessages++;
            if (this.numberOfSentMessages > MAX_SENT_MESSAGES)
                throw new Exception("Maximum of " + MAX_SENT_MESSAGES + " messages allowed per session!");
        }

    }
}
