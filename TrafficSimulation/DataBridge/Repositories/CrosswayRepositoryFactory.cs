using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;
using Repositories;
using DataBridge;
using DataBridge.Services;

namespace Repositories
{
    /// <summary>
    /// Factory class to decouple components.
    /// </summary>
    public abstract class CrosswayRepositoryFactory
    {
        /// <summary>
        /// Factory to return new service. 
        /// </summary>
        /// <returns>CrosswayService</returns>
        public static ICrosswayRepository CreateRepository()
        {
            return new CrosswayService();
        }
    }
}
