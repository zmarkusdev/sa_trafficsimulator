using System;
using Technics;

namespace SimulationUserInterface.Models
{
    public class PositionModel : Model
    {

        #region ----- Variables

        private int _PositionId;
        /// <summary>
        /// Position Id as it comes from the backend
        /// </summary>
        public int PositionId
        {
            get { return _PositionId; }
            set
            {
                if (_PositionId != value)
                {
                    _PositionId = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int _XPosition;
        /// <summary>
        /// Current XPosition of the point on the x-axis in pixel
        /// </summary>
        public int XPosition
        {
            get { return _XPosition; }
            set
            {
                if (_XPosition != value)
                {
                    _XPosition = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int _YPosition;
        /// <summary>
        /// Current YPosition of the point on the y-axis in pixel
        /// </summary>
        public int YPosition
        {
            get { return _YPosition; }
            set
            {
                if (_YPosition != value)
                {
                    _YPosition = value;
                    RaisePropertyChanged();
                }
            }
        }

        private double _XScaleFactor;
        /// <summary>
        /// Current x-scale factor of the map compared with the initial value
        /// is for resizing the point on the map after the windowsize is changed
        /// </summary>
        public double XScaleFactor
        {
            get { return _XScaleFactor; }
            set
            {
                if (_XScaleFactor != value)
                {
                    _XScaleFactor = value;
                    RaisePropertyChanged();
                }
            }
        }

        private double _YScaleFactor;
        /// <summary>
        /// Current y-scale factor of the map compared with the initial value
        /// is for resizing the point on the map after the windowsize is changed
        /// </summary>
        public double YScaleFactor
        {
            get { return _YScaleFactor; }
            set
            {
                if (_YScaleFactor != value)
                {
                    _YScaleFactor = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion


        #region ----- Constructor 

        /// <summary>
        /// Constructor which saves the shown position of a point for the UI
        /// </summary>
        /// <param name="xpos">X value of the position</param>
        /// <param name="ypos">Y value of the position</param>
        /// <param name="xScale">Calculated x-scale factor of the window</param>
        /// <param name="yScale">Calculated y-scale factor of the window</param>
        public PositionModel(int positionid, int xpos, int ypos, double xscale, double yscale)
        {
            PositionId = positionid;
            XPosition = xpos;
            YPosition = ypos;
            XScaleFactor = xscale;
            YScaleFactor = yscale;

            /// Bind the command to the function
            PositionClickCommand = new Command(() => PositionClickCommandExecute());
        }

        #endregion

        public Command PositionClickCommand { get; }
        /// <summary>
        /// Function that shows the actual id and location of the current position
        /// This function is for street creation usage and has no influence in normal simulation usage
        /// </summary>
        private void PositionClickCommandExecute()
        {
            try
            {
                Console.WriteLine("PositionId {0} on Position > {1} | v {2}", PositionId, XPosition, YPosition);
            }
            catch
            {
                
            }
        }

    } // Class
} // Namespace
