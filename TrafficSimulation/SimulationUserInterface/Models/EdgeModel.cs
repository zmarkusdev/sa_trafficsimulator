using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technics;

namespace SimulationUserInterface.Models
{

    /// <summary>
    /// Class holding the information of a Edge and enable it to show the Edge in the UI
    /// </summary>
    public class EdgeModel : Model
    {

        #region ----- Variables

        private int _X1Position;
        /// <summary>
        /// Current X value of the starting point in pixel
        /// </summary>
        public int X1Position
        {
            get { return _X1Position; }
            set
            {
                if (_X1Position != value)
                {
                    _X1Position = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int _Y1Position;
        /// <summary>
        /// Current Y value of the starting point in pixel
        /// </summary>
        public int Y1Position
        {
            get { return _Y1Position; }
            set
            {
                if (_Y1Position != value)
                {
                    _Y1Position = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int _X2Position;
        /// <summary>
        /// Current X value of the ending point in pixel
        /// </summary>
        public int X2Position
        {
            get { return _X2Position; }
            set
            {
                if (_X2Position != value)
                {
                    _X2Position = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int _Y2Position;
        /// <summary>
        /// Current Y value of the ending point in pixel
        /// </summary>
        public int Y2Position
        {
            get { return _Y2Position; }
            set
            {
                if (_Y2Position != value)
                {
                    _Y2Position = value;
                    RaisePropertyChanged();
                }
            }
        }

        private double _XScaleFactor;
        /// <summary>
        /// Current x-scale factor of the map compared with the initial value
        /// is for resizing the line on the map after the windowsize is changed
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
        /// is for resizing the line on the map after the windowsize is changed
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
        /// Constructor which saves the position of the edge start and endpoints
        /// </summary>
        /// <param name="x1pos">X position of the start point</param>
        /// <param name="y1pos">Y position of the start point</param>
        /// <param name="x2pos">X position of the end point</param>
        /// <param name="y2pos">Y position of the end point</param>
        /// <param name="xScale">Calculated x-scale factor of the window</param>
        /// <param name="yScale">Calculated y-scale factor of the window</param>
        public EdgeModel(int x1pos, int y1pos, int x2pos, int y2pos, double xScale, double yScale)
        {
            X1Position = x1pos;
            Y1Position = y1pos;
            X2Position = x2pos;
            Y2Position = y2pos;
            XScaleFactor = xScale;
            YScaleFactor = yScale;
        }

        #endregion

    } // Class
} // Namepsace
