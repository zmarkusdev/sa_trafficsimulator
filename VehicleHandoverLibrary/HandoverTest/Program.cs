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
            // Create service
            var service = new VehicleHandoverLibrary.VehicleHandoverService(VehicleHandoverLibrary.Groups.GROUP02);

            // Subscribe to event
            service.ReceiveEventHandler += Service_ReceiveEventHandler;

            // Add a dummy vehicle
            var vehicle = new VehicleHandoverLibrary.Vehicle();
            vehicle.Length = 5;
            vehicle.Width = 2.3;
            vehicle.MaxAcceleration = 9.81;
            vehicle.MaxDeceleration = 12.3;
            vehicle.MaxVelocity = 300;
            vehicle.Type = VehicleHandoverLibrary.VehicleType.CAR;
            service.HandoverVehicle(vehicle);

            Console.ReadLine();
        }

        private static void Service_ReceiveEventHandler(object sender, VehicleHandoverLibrary.VehicleEventArgs e)
        {
            Console.WriteLine(e.Vehicle.ToString());
        }

    }
}
