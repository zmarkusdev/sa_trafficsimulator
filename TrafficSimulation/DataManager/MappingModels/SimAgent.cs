﻿using Datamodel;
using System;
using System.Collections.Generic;

namespace DataManager.MappingModels
{
    /// <summary>
    /// Simulation specific data for the agent which will not be transferred to the data access
    /// </summary>
    public class SimAgent : Agent, ICloneable
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
            VehicleWidth = agent.VehicleWidth;
            Route = new Queue<AbstractEdge>();
            CurrentAccelerationExact = agent.Acceleration;
            CurrentVelocityExact = agent.CurrentVelocity;
            RunLengthExact = agent.RunLength;
            IsActive = agent.IsActive;
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

        /// <summary>
        /// Clones the current instance of SimAgent to a new object copy
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new SimAgent
            {
                Id = this.Id,
                CurrentVelocity = this.CurrentVelocity,
                EdgeId = this.EdgeId,
                RunLength = this.RunLength,
                Type = this.Type,
                Acceleration = this.Acceleration,
                Deceleration = this.Deceleration,
                MaxVelocity = this.MaxVelocity,
                VehicleLength = this.VehicleLength,
                VehicleWidth = this.VehicleWidth,
                Route = this.Route,
                CurrentAccelerationExact = this.CurrentAccelerationExact,
                CurrentVelocityExact = this.CurrentVelocityExact,
                RunLengthExact = this.RunLengthExact,
                IsActive = this.IsActive
            };
        }

        /// <summary>
        /// Converts the current SimAgent instance to an instance of type agent
        /// </summary>
        /// <returns></returns>
        public Agent ToAgent()
        {
            return new Agent
            {
                Id = Id,
                CurrentVelocity = CurrentVelocity,
                EdgeId = EdgeId,
                RunLength = RunLength,
                Type = Type,
                Acceleration = Acceleration,
                Deceleration = Deceleration,
                MaxVelocity = MaxVelocity,
                VehicleLength = VehicleLength,
                VehicleWidth = VehicleWidth,
                IsActive = IsActive
            };
        }
    }
}
