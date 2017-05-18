using DataAccessLayer.Communication;
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
        }
    }
}
