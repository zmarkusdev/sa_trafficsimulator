using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Amazon.SQS;
using Amazon.SQS.Model;
using Amazon.Runtime;
using System.Threading;

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

        private AWSCredentials awsCredentials;
        private AmazonSQSClient sqsClient;
        private String sqsUrl;
        private int sentMessages;

        private String MESSAGE_GROUP_ID = "1";
        private int MAX_MESSAGES = 500;

        public VehicleHandoverService(Groups group)
        {
            // Setup AWS Credentials
            this.awsCredentials = new BasicAWSCredentials("AKIAJAXVEF37WTBOI5RA", "K78sgjKL3XRD/T4T8/8yubFroIQ8PtvZBQ2yq5r+");
            this.sqsClient = new AmazonSQSClient(awsCredentials, Amazon.RegionEndpoint.USEast2);

            // Get SQS_URL
            this.sqsUrl = Group.getUrlForGroup(group);

            // Initialize
            this.sentMessages = 0;

            // Start polling
            Task task = new Task(() => startLongPolling());
            task.Start();
        }

        public void HandoverVehicle(Vehicle vehicle)
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
            this.sentMessages++;

            if (sentMessages > MAX_MESSAGES)
                throw new Exception("Maximum of " + MAX_MESSAGES + " messages allowed per session!");
        }

        private void startLongPolling()
        {
            while(true)
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
                    } catch (Exception e)
                    {
                        Console.WriteLine("Couldn't parse JSON");
                    }

                    // Delete it
                    var deleteMessageRequest = new DeleteMessageRequest(sqsUrl, message.ReceiptHandle);
                    sqsClient.DeleteMessage(deleteMessageRequest);
                }
            }
        }

    }
}
