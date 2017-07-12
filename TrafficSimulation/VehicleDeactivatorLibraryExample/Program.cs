using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleDeactivatorLibrary;

namespace VehicleDeactivatorLibraryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var messageReceiver = new MessageReceiver();
            messageReceiver.ReceiveEventHandler += MessageReceiver_ReceiveEventHandler;

            var messageSender = new MessageSender();
            while(true)
            {
                messageSender.ToggleVehicle(1);
                Thread.Sleep(1000);
            }            
            
        }

        private static void MessageReceiver_ReceiveEventHandler(object sender, MessageEventArgs e)
        {
            System.Console.WriteLine(e.Message.ToString());
        }
    }
}
