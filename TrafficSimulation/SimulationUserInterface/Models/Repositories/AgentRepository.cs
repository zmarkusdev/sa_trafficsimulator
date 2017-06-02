using Datamodel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SimulationUserInterface.Models
{
    /// <summary>
    /// Repository of all Agents which should be shown in the User Interface
    /// </summary>
    public class AgentRepository
    {
        #region ----- Variables 

        /// <summary>
        /// GUI X scale factor for repositioning and resizing the positions
        /// </summary>
        private double XScaleFactor { get; set; }

        /// <summary>
        /// GUI Y scale factor for repositioning and resizing the positions
        /// </summary>
        private double YScaleFactor { get; set; }

        /// <summary>
        /// Collection of agent elements which should be shown in the User Interface
        /// </summary>
        public ObservableCollection<AgentModel> MapAgents { get; set; }

        #endregion



        #region ----- Constructor

        /// <summary>
        /// Default Constructor which has to initialize the ObservableCollection of AgentModels
        /// </summary>
        public AgentRepository()
        {
            MapAgents = new ObservableCollection<AgentModel>();
        }

        #endregion



        #region --- Public functions

        /// <summary>
        /// Update the scales for repositioning and resizing the edge elements
        /// </summary>
        /// <param name="xScaleFactor">X</param>
        /// <param name="yScaleFactor">Y</param>
        public void SetScaleFactors(double xScaleFactor, double yScaleFactor)
        {
            try
            {
                /// Set the scale factors (set to 1 if they are zero to prevent a possible division through 0)
                XScaleFactor = (xScaleFactor == 0.0) ? 1 : xScaleFactor;
                YScaleFactor = (yScaleFactor == 0.0) ? 1 : yScaleFactor;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Deletes all existing AgentModels and creates new ones with the given
        /// position, edge and agens information
        /// </summary>
        /// <param name="positions">Positions from the DataBridge</param>
        /// <param name="edges">Edges from the DataBridge</param>
        /// <param name="agents">Agents from the DataBridge</param>
        public void DrawAgents(IEnumerable<Position> positions, IEnumerable<Edge> edges, IEnumerable<Agent> agents)
        {
            try
            {
                /// Delete all old Agens
                MapAgents.Clear();

                foreach (Agent singleagent in agents)
                {
                    /// Get the edge on which the agent is
                    Edge agentEdge = edges.Where(var => var.Id == singleagent.EdgeId).ToList().First();
                    
                    /// Get start and end position
                    Position startposition = positions.Where(var => var.Id == agentEdge.StartPositionId).ToList().First();
                    Position endposition = positions.Where(var => var.Id == agentEdge.EndPositionId).ToList().First();

                    /// Calculate position difference of the points
                    int xPositionDifference = endposition.X - startposition.X;
                    int yPositionDifference = endposition.Y - startposition.Y;

                    /// Calculate angle for agent rotation
                    double angle = Math.Atan2(yPositionDifference, xPositionDifference);

                    /// Calculate new absolute position of the agent
                    int xAgent = (int)Math.Round(startposition.X + Math.Cos(angle) * singleagent.RunLength);
                    int yAgent = (int)Math.Round(startposition.Y + Math.Sin(angle) * singleagent.RunLength);

                    /// Add a new agent with creted information
                    //MapAgents.Add(new AgentModel(singleagent.Id, xAgent, yAgent, -90 + (angle / Math.PI * 180), singleagent.Type, singleagent.VehicleWidth, singleagent.VehicleLength, XScaleFactor, YScaleFactor, singleagent.IsActive));
                    MapAgents.Add(new AgentModel(singleagent.Id, xAgent, yAgent, -90 + (angle / Math.PI * 180), singleagent.Type, singleagent.VehicleWidth, singleagent.VehicleLength, singleagent.IsActive));

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion
    } // Class
} // Namespace
