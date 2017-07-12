///////////////////////////////////////////////////////////
//  Agent.cs
//  Implementation of the Class Agent
//  Generated by Enterprise Architect
//  Created on:      15-Apr-2017 16:36:47
//  Original author: David
///////////////////////////////////////////////////////////


namespace Datamodel
{

    /// <summary>
    /// Agent model containing informations about a single vehicle on the map.
    /// </summary>
	public class Agent : BaseModel {

        /// <summary>
        /// Current velocity of the agent in m/s
        /// </summary>
		public int CurrentVelocity { get; set; }
        
        /// <summary>
        /// Id of the edge the current agent is on
        /// </summary>
		public int EdgeId { get; set; }

        /// <summary>
        /// Current length in meter the current agent is on the current edge
        /// </summary>
        public int RunLength { get; set; }
        
        /// <summary>
        /// Specifies which type the agent is, controls rendering and configuration for spawning
        /// </summary>
		public AgentType Type { get; set; }

        /// <summary>
        /// Max allowed acceleration for the current agent in m/s^2
        /// </summary>
		public int Acceleration { get; set; }

        /// <summary>
        /// Max allowed deceleration for the current agent in m/s^2
        /// </summary>
		public int Deceleration { get; set; }

        /// <summary>
        /// Max allowed velocity for the current agent in m/s
        /// </summary>
		public int MaxVelocity { get; set; }

        /// <summary>
        /// Vehicle length in meters
        /// </summary>
        public int VehicleLength { get; set; }

        /// <summary>
        /// Vehicle width in meters
        /// </summary>
        public int VehicleWidth { get; set; }

        /// <summary>
        /// State isActive=false marks vehicles as broken and gui and physics engine will respond accordingly
        /// </summary>
        public bool IsActive { get; set; } = true;

    }//end Agent

}//end namespace Datamodel