using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicEngine
{
    /// <summary>
    /// Interface for the physics engine of the vehicle simulation
    /// </summary>
    public interface IPhysicEngine
    {
        /// <summary>
        /// Starts the physics engine of the vehicle simulation
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the physics engine of the vehicle simulation
        /// </summary>
        void Stop();
    }
}
