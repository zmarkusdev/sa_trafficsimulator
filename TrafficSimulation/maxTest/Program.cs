using DataAccessLayer.Communication;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace maxTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string address = "net.pipe://localhost/ttrafficSim/DataAccessService";

            NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            EndpointAddress ep = new EndpointAddress(address);
            IDataAccessContract channel = ChannelFactory<IDataAccessContract>.CreateChannel(binding, ep);

            var agents = channel.GetAllAgents();

            Console.WriteLine("Client Connected");


            Console.WriteLine("Fertig");
            Console.ReadKey();

        }
    }
}
