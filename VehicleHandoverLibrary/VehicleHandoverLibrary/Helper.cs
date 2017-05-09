using Amazon.Runtime;
using Amazon.SQS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleHandoverLibrary
{
    class Helper
    {
        public static AmazonSQSClient GetSQSClient()
        {
            var awsCredentials = new BasicAWSCredentials("AKIAJAXVEF37WTBOI5RA", "K78sgjKL3XRD/T4T8/8yubFroIQ8PtvZBQ2yq5r+");
            var sqsClient = new AmazonSQSClient(awsCredentials, Amazon.RegionEndpoint.USEast2);
            return sqsClient;
        }
    }
}
