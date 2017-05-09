using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandoverTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Receiver & Subscribe
            var vehicleReceiver = new VehicleHandoverLibrary.VehicleReceiver(VehicleHandoverLibrary.Groups.GROUP02);
            vehicleReceiver.ReceiveEventHandler += VehicleReceiver_ReceiveEventHandler;

            // Create sender
            var vehicleSender = new VehicleHandoverLibrary.VehicleSender(VehicleHandoverLibrary.Groups.GROUP02);

            // Define dummy vehicle
            var vehicle = new VehicleHandoverLibrary.Vehicle();
            vehicle.Length = 5;
            vehicle.Width = 2.3;
            vehicle.MaxAcceleration = 9.81;
            vehicle.MaxDeceleration = 12.3;
            vehicle.MaxVelocity = 300;
            vehicle.Type = VehicleHandoverLibrary.VehicleType.CAR;
            
            while(true)
            {
                Console.WriteLine("Press any key to send a dummy vehicle");
                Console.WriteLine("Press 'q' to quit");
                var input = Console.ReadKey();

                if (input.KeyChar == 'q')
                {
                    return;
                } else
                {
                    vehicleSender.PushVehicle(vehicle);
                    Console.WriteLine("Pushed vehicle!");
                }
                    
            }
        }

        private static void VehicleReceiver_ReceiveEventHandler(object sender, VehicleHandoverLibrary.VehicleEventArgs e)
        {
            Console.WriteLine("Received " + e.Vehicle.ToString());
        }

    }
}
