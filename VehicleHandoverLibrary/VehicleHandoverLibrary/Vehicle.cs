using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VehicleHandoverLibrary
{
    public enum VehicleType { CAR, TRUCK, BIKE };

    public class Vehicle
    {
        // Maximum acceleration in m/s^2
        public double MaxAcceleration { get; set; }

        // Maximum deceleration in m/s^2
        public double MaxDeceleration { get; set; }

        // Maximum velocity in m/s
        public double MaxVelocity { get; set; }

        // With of the vehicle in m
        public double Width { get; set; }

        // Length of the vehicle in m
        public double Length { get; set; }

        // Type of the vehicle (see enum VehicleType)
        public VehicleType Type { get; set; }

        public String toJSON()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Vehicle fromJSON(String json)
        {
            return JsonConvert.DeserializeObject<Vehicle>(json);
        }

        override
        public String ToString()
        {
            return "Vehicle: " + this.toJSON();
        }

    }
}
