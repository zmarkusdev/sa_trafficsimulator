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
        public double MaxAcceleration { get; set; }
        public double MaxDeceleration { get; set; }
        public double MaxVelocity { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
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
