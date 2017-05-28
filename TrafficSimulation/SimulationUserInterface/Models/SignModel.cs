using Technics;

namespace SimulationUserInterface.Models
{
    public class SignModel : Model
    {

        #region ----- Variables

        private int _SignId;
        /// <summary>
        /// ID of a sign with that it can be identified
        /// </summary>
        public int SignId
        {
            get { return _SignId; }
            set
            {
                if (_SignId != value)
                {
                    _SignId = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int _XPosition;
        /// <summary>
        /// Current XPosition of the sign on the x-axis in pixel
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
        /// Current YPosition of the sign on the y-axis in pixel
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
        /// is for resizing the sign on the map after the windowsize is changed
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
        /// is for resizing the sign on the map after the windowsize is changed
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

        private int _SignWidth;
        /// <summary>
        /// With of the sign in pixel
        /// </summary>
        public int SignWidth
        {
            get { return _SignWidth; }
            set
            {
                if (_SignWidth != value)
                {
                    _SignWidth = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int _SignHeight;
        /// <summary>
        /// Height of the sign in pixel
        /// </summary>
        public int SignHeight
        {
            get { return _SignHeight; }
            set
            {
                if (_SignHeight != value)
                {
                    _SignHeight = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _ImagePath;
        /// <summary>
        /// Path of the image for showing the sign on the UI
        /// </summary>
        public string ImagePath
        {
            get { return _ImagePath; }
            set
            {
                if (_ImagePath != value)
                {
                    _ImagePath = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion



        #region ----- Constructor

        /// <summary>
        /// Constructor which calculates the positions/with and selects a picture for the view
        /// </summary>
        /// <param name="signId">ID of the sing</param>
        /// <param name="xPosition">Original x-position where the sign should be placed on the screen</param>
        /// <param name="yPosition">Original y-position where the sign should be placed on the screen</param>
        /// <param name="signWidth">With of the sign</param>
        /// <param name="signHeight">Height of the sign</param>
        /// <param name="xScale">Calculated x-scale factor of the window</param>
        /// <param name="yScale">Calculated y-scale factor of the window</param>
        public SignModel(int signId, int xPosition, int yPosition, int signWidth, int signHeight, double xScale, double yScale)
        {
            SignId = signId;

            XPosition = xPosition - SignWidth * 10 / 2;
            YPosition = yPosition - SignHeight * 10 / 2;

            SignWidth = signWidth * 10;
            SignHeight = signHeight * 10;

            XScaleFactor = xScale;
            YScaleFactor = yScale;

            //ToDo: Sign Type enablen wenn typ vorhanden
            //switch (signType)
            //{
            //    case SignType.Stopp:
            //        ImagePath = "pack://application:,,,/Resources/SignStopp.png";
            //        break;

            //    default:
            //        break;
            //}
        }

        #endregion

    } // Class
} // Namespace
