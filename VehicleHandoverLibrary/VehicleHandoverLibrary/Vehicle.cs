using Newtonsoft.Json;
using System;

namespace VehicleHandoverLibrary
{

    /// <summary>
    /// Type definition of the vehicle
    /// </summary>
    public enum VehicleType
    {
        /// <summary>
        /// Car
        /// </summary>
        CAR,
        /// <summary>
        /// Truck
        /// </summary>
        TRUCK,
        /// <summary>
        /// Motorbike
        /// </summary>
        BIKE
    };

    /// <summary>
    /// Vehicle class with basic information for handover library that has basic information of a vehicle for all groups
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Maximum acceleration in m/s^2
        /// </summary>
        public double MaxAcceleration { get; set; }

        /// <summary>
        /// Maximum deceleration in m/s^2
        /// </summary>
        public double MaxDeceleration { get; set; }

        /// <summary>
        /// Maximum velocity in m/s
        /// </summary>
        public double MaxVelocity { get; set; }

        /// <summary>
        /// With of the vehicle in m
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Length of the vehicle in m
        /// </summary>
        public double Length { get; set; }

        /// <summary>
        /// Type of the vehicle (see enum VehicleType)
        /// </summary>
        public VehicleType Type { get; set; }

        /// <summary>
        /// Converts a Vehicle into json
        /// </summary>
        /// <returns>Json formated vehicle</returns>
        public String toJSON()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Returns a Vehicle from a json serialized string
        /// </summary>
        /// <param name="json">Json formated vehicle</param>
        /// <returns>Vehicle object</returns>
        public static Vehicle fromJSON(String json)
        {
            return JsonConvert.DeserializeObject<Vehicle>(json);
        }

        /// <summary>
        /// Prints the vehicle json string
        /// </summary>
        /// <returns></returns>
        override public String ToString()
        {
            return "Vehicle: " + this.toJSON();
        }

    }
}
