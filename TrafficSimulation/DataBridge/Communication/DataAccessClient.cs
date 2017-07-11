using DataAccessLayer.Communication;
using System;
using System.ServiceModel;

namespace DataBridge.Communication
{
    internal class DataAccessClient
    {
        internal static DataAccessClient Instance = new DataAccessClient();

        internal IDataAccessContract Channel;

        private DataAccessClient()
        {
            string address = "net.pipe://localhost/trafficSim/DataAccessService";

            NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            EndpointAddress ep = new EndpointAddress(address);
            Channel = ChannelFactory<IDataAccessContract>.CreateChannel(binding, ep);
            // Warte, bis der Server da ist
            bool isAliveFlag = false;
            do
            {
                try
                {
                    System.Threading.Thread.Sleep(1500);
                    isAliveFlag = Channel.isAlive();
                }
                catch (Exception)
                {
                    Console.WriteLine("Still waiting for the DataAccessServer to come up.");
                }
            } while (!isAliveFlag);

        }
    }
}
