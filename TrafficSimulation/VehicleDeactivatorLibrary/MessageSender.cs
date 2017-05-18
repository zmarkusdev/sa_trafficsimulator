using Amazon.SQS;
using Amazon.SQS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleDeactivatorLibrary
{
    public class MessageSender
    {

        // Propeties
        private AmazonSQSClient sqsClient;
        private int numberOfSentMessages;

        // Constants
        private const String MESSAGE_GROUP_ID = "01";
        private const int MAX_SENT_MESSAGES = 500;
        private String SQS_URL;

        // Constructor
        public MessageSender()
        {
            // Instantiate SQS client
            this.sqsClient = Helper.GetSQSClient();
            this.SQS_URL = Helper.GetSQSUrl();
        }

        public void PushMessage(Message message)
        {
            Task task = new Task(() => sendMessage(message.toJSON()));
            task.Start();
        }

        private void sendMessage(String message)
        {
            var sendMessageRequest = new SendMessageRequest(SQS_URL, message);
            sendMessageRequest.MessageGroupId = MESSAGE_GROUP_ID;
            sendMessageRequest.MessageDeduplicationId = Guid.NewGuid().ToString();
            sqsClient.SendMessage(sendMessageRequest);
            this.numberOfSentMessages++;

            if (this.numberOfSentMessages > MAX_SENT_MESSAGES)
                throw new Exception("Maximum of " + MAX_SENT_MESSAGES + " messages allowed per session!");
        }

    }
}
