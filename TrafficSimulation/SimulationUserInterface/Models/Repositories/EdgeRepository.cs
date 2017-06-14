using Datamodel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SimulationUserInterface.Models
{
    /// <summary>
    /// Repository of all Edges which should be shown in the User Interface
    /// </summary>
    public class EdgeRepository
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
        /// Collection of edge elements which should be shown in the User Interface
        /// </summary>
        public ObservableCollection<EdgeModel> MapEdges { get; set; }

        #endregion



        #region ----- Constructor

        /// <summary>
        /// Default Constructor which has to initialize the ObservableCollection of EdgeModels
        /// </summary>
        public EdgeRepository()
        {
            MapEdges = new ObservableCollection<EdgeModel>();
        }

        #endregion



        #region ----- Public functions

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
        /// Deletes all existing EdgeModels and creates new ones with the given 
        /// position and edge information
        /// </summary>
        /// <param name="positions">Positions from the DataBridge</param>
        /// <param name="edges">Edges from the DataBridge</param>
        public void DrawEdges(IEnumerable<Position> positions, IEnumerable<Edge> edges)
        {
            try
            {
                /// Delete all old Edges
                MapEdges.Clear();

                foreach (Edge singleEdge in edges)
                {
                    /// Get the start and end position IDs from the used edge
                    int startPositionId = singleEdge.StartPositionId;
                    int endPositionId = singleEdge.EndPositionId;

                    /// Get the used positions from the list by its ID
                    Position startposition = positions.Where(var => var.Id == startPositionId).ToList().First();
                    Position endposition = positions.Where(var => var.Id == endPositionId).ToList().First();
                    
                    /// Add a new edge with created information
                    MapEdges.Add(new EdgeModel(startposition.X, startposition.Y, endposition.X, endposition.Y, XScaleFactor, YScaleFactor));
                    //Console.WriteLine($"Edge:{singleEdge.Id.ToString()} on pos {startPositionId.ToString()}, {endPositionId.ToString()} placed in memory. Positions: {positions.ToList().Count}");
                }
            }
            catch (Exception ex)
            {
                //Console.Write(ex.Message);
            }
        }

        #endregion
    } // Class
} // Namespace
