using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleHandoverLibrary
{
    public class VehicleEventArgs : EventArgs
    {
        public Vehicle Vehicle { get; }

        public VehicleEventArgs(Vehicle vehicle)
        {
            this.Vehicle = vehicle;
        }
    }
}
