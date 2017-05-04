using Datamodel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SimulationUserInterface.Models
{
    /// <summary>
    /// Repository of all Signs which should be shown in the User Interface
    /// </summary>
    public class SignRepository
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
        /// Collection of sign elements which should be shown in the User Interface
        /// </summary>
        public ObservableCollection<SignModel> MapSigns { get; set; }

        #endregion



        #region ----- Constructor

        /// <summary>
        /// Default Constructor which has to initialize the ObservableCollection of SignModels
        /// </summary>
        public SignRepository()
        {
            MapSigns = new ObservableCollection<SignModel>();
        }

        #endregion

        #region ----- public functions

        /// <summary>
        /// Update the scales for repositioning and resizing the sign elements
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
        /// Delete all existing SignModels and creates new ones with the given
        /// position, edge and rule information
        /// </summary>
        /// <param name="positions">Positions from the DataBridge</param>
        /// <param name="edges">Edges from the DataBridge</param>
        /// <param name="signs">Rules from the DataBridge</param>
        public void DrawSigns(IEnumerable<Position> positions, IEnumerable<Edge> edges, IEnumerable<Rule> signs)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
