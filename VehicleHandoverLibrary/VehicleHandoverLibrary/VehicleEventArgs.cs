using System;

namespace VehicleHandoverLibrary
{

    /// <summary>
    /// Event Argument holding a vehicle
    /// </summary>
    public class VehicleEventArgs : EventArgs
    {

        /// <summary>
        /// Vehicle to send/receive
        /// </summary>
        public Vehicle Vehicle { get; }

        /// <summary>
        /// Transform the vehicle to an event
        /// </summary>
        /// <param name="vehicle"></param>
        public VehicleEventArgs(Vehicle vehicle)
        {
            this.Vehicle = vehicle;
        }
    }
}
