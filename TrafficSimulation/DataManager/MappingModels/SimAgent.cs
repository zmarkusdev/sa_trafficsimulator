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
        /// Initializes a new simulation specific agent object, copy constructor for base class objects
        /// </summary>
        public SimAgent(Agent agent) : base()
        {
            Id = agent.Id;
            CurrentVelocity = agent.CurrentVelocity;
            EdgeId = agent.EdgeId;
            RunLength = agent.RunLength;
            Type = agent.Type;
            Acceleration = agent.Acceleration;
            Deceleration = agent.Deceleration;
            MaxVelocity = agent.MaxVelocity;
            VehicleLength = agent.VehicleLength;
            Route = new Queue<AbstractEdge>();
            CurrentAccelerationExact = agent.Acceleration;
            CurrentVelocityExact = agent.CurrentVelocity;
            RunLengthExact = agent.RunLength;
        }

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
        public double CurrentAccelerationExact { get; set; }

        /// <summary>
        /// The current exact velocity of this agent
        /// </summary>
        public double CurrentVelocityExact { get; set; }

        /// <summary>
        /// The current exact run length of this agent
        /// </summary>
        public double RunLengthExact { get; set; }
    }
}
