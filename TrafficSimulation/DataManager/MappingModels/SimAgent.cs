using Datamodel;
using System.Collections.Generic;

namespace DataManager.MappingModels
{
    /// <summary>
    /// Simulation specific data for the agent which will not be transferred to the data access
    /// </summary>
    public class SimAgent : Agent
    {
        /// <summary>
        /// Initializes a new simulation specific agent object
        /// </summary>
        public SimAgent() : base()
        {
            Route = new Queue<AbstractEdge>();
        }

        /// <summary>
        /// The route the agent wants to travel on
        /// </summary>
        public Queue<AbstractEdge> Route { get; set; }

        /// <summary>
        /// The current acceleration of this agent
        /// </summary>
        public int CurrentAcceleration { get; set; }        
    }
}
