using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Amazon.SQS;
using Amazon.SQS.Model;
using Amazon.Runtime;

/*
 * QUEUE Options:
 *  Default Visibility Timeout: 2m
 *  Message Retention Period: 1m
 *  Receive Message Wait Time (Long-polling): 20s
 *  Content-Based Deduplication: false
 */

namespace VehicleHandoverLibrary
{
    public class VehicleHandoverService
    {

        AWSCredentials awsCredentials;
        AmazonSQSClient sqsClient;
        String SQS_URL = "https://sqs.us-east-2.amazonaws.com/047952185359/vehicle-handover-01.fifo";
        String MESSAGE_GROUP_ID = "1";

        public VehicleHandoverService()
        {
            awsCredentials = new BasicAWSCredentials("AKIAJAXVEF37WTBOI5RA", "K78sgjKL3XRD/T4T8/8yubFroIQ8PtvZBQ2yq5r+");
            sqsClient = new AmazonSQSClient(awsCredentials, Amazon.RegionEndpoint.USEast2);

            //sendMessage("I bims!");
            var messages = receiveMessage();
            Console.WriteLine(messages);
        }

        private void sendMessage(String message)
        {
            var sendMessageRequest = new SendMessageRequest(SQS_URL, message);
            sendMessageRequest.MessageGroupId = MESSAGE_GROUP_ID;
            sendMessageRequest.MessageDeduplicationId = Guid.NewGuid().ToString();
            sqsClient.SendMessage(sendMessageRequest);
        }

        private String receiveMessage()
        {
            String response = "";
            var receiveMessageRequest = new ReceiveMessageRequest(SQS_URL);
            var receiveMessageResponse = sqsClient.ReceiveMessage(receiveMessageRequest);

            foreach (var message in receiveMessageResponse.Messages)
            {
                response += "[" + message.Body + "]";

                // Delete it
                var deleteMessageRequest = new DeleteMessageRequest(SQS_URL, message.ReceiptHandle);
                sqsClient.DeleteMessage(deleteMessageRequest);
            }

            return response;
        }

    }
}
