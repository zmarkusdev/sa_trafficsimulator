using Datamodel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SimulationUserInterface.Models
{
    /// <summary>
    /// Repository for all Positions which should be shown in the User Interface
    /// </summary>
    public class PositionRepository
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
        /// Collection of position elements which should be shown in the User Interface
        /// </summary>
        public ObservableCollection<PositionModel> MapPositions { get; set; }

        #endregion



        #region ----- Constructor

        /// <summary>
        /// Default Constructor which has to initialize the ObservableCollection of PositionModels
        /// </summary>
        public PositionRepository()
        {
            MapPositions = new ObservableCollection<PositionModel>();
        }

        #endregion



        #region ----- Public functions

        /// <summary>
        /// Update the scales for repositioning and resizing the position elements
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
        /// Deletes all existing PositionModels and creates new ones with the given Position information
        /// </summary>
        /// <param name="positions">Positions from the DataBridge</param>
        public void DrawPositions(IEnumerable<Position> positions)
        {
            try
            {
                /// Delete all old positions
                MapPositions.Clear();

                foreach (Position singleposition in positions)
                {
                    /// Add a new position with created information
                    MapPositions.Add(new PositionModel(singleposition.Id, singleposition.X, singleposition.Y, XScaleFactor, YScaleFactor));
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
