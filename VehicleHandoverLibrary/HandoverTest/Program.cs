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
            var service = new VehicleHandoverLibrary.VehicleHandoverService(VehicleHandoverLibrary.Groups.GROUP02);

            var vehicle = new VehicleHandoverLibrary.Vehicle();
            vehicle.Length = 5;
            vehicle.Width = 2.3;
            vehicle.MaxAcceleration = 9.81;
            vehicle.MaxDeceleration = 12.3;
            vehicle.MaxVelocity = 300;
            vehicle.Type = VehicleHandoverLibrary.VehicleType.CAR;

            service.HandoverVehicle(vehicle);
        }
    }
}
