using DataAccessLayer.Communication;
using Datamodel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            string address = "net.pipe://localhost/trafficSim/DataAccessService";

            ServiceHost serviceHost = new ServiceHost(typeof(DataAccessService));
            NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            serviceHost.AddServiceEndpoint(typeof(IDataAccessContract), binding, address);
            try
            {
                serviceHost.Open();
                Console.WriteLine("Listening... press a key to stop.");
                Console.ReadKey();
                serviceHost.Close();
            }
            catch (TimeoutException timeProblem)
            {
                Console.WriteLine(timeProblem.Message);
                Console.ReadLine();
            }
            catch (CommunicationException commProblem)
            {
                Console.WriteLine(commProblem.Message);
                Console.ReadLine();
            }
        }
    }
}
