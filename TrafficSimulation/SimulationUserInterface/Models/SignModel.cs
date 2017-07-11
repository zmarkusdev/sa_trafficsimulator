using Datamodel;
using Technics;

namespace SimulationUserInterface.Models
{

    /// <summary>
    /// Class for holding the information of a sign and enable it to show it in the UI
    /// </summary>
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
        /// <param name="type">Ruletype that shows which kind of rule it is (for printing the right sign)</param>
        /// <param name="maxVelocity">Information that shows in addition to the rule type if a traffic light is green or red</param>
        /// <param name="xScale">Calculated x-scale factor of the window</param>
        /// <param name="yScale">Calculated y-scale factor of the window</param>
        public SignModel(int signId, int xPosition, int yPosition, RuleType type, int maxVelocity, double xScale, double yScale)
        {
            SignId = signId;
            
            SignWidth =  16;
            SignHeight =  16;

            XScaleFactor = xScale;
            YScaleFactor = yScale;

            switch (type)
            {
                case RuleType.Stopp:
                    ImagePath = "pack://application:,,,/Resources/Stopp.png";
                    break;
                case RuleType.Vorrang:
                    ImagePath = "pack://application:,,,/Resources/VorrangGeben.png";
                    break;
                case RuleType.Ampel:

                    // Overwrite the sign height because traffic lights are larger
                    SignHeight = 45;

                    if (maxVelocity < 1)
                    {
                        ImagePath = "pack://application:,,,/Resources/AmpelRot.png";
                    }
                    else
                    {
                        ImagePath = "pack://application:,,,/Resources/AmpelGruen.png";
                    }
                    break;
                case RuleType.Geschwindigkeit:
                    ImagePath = "pack://application:,,,/Resources/Geschwindigkeitsbegrenzung.png";
                    break;
                default:
                    ImagePath = "pack://application:,,,/Resources/Stopp.png";
                    break;
            }

            // Calculate the position after the size is known
            XPosition = xPosition - SignWidth / 2;
            YPosition = yPosition - SignHeight / 2;

        }

        /// <summary>
        /// Constructor which calculates the position/with ans selects a picture for the view
        /// This constructor ignores the resizing functionality in order to increase performance
        /// </summary>
        /// <param name="signId">ID of the sing</param>
        /// <param name="xPosition">Original x-position where the sign should be placed on the screen</param>
        /// <param name="yPosition">Original y-position where the sign should be placed on the screen</param>
        /// <param name="type">Ruletype that shows which kind of rule it is (for printing the right sign)</param>
        /// <param name="maxVelocity">Information that shows in addition to the rule type if a traffic light is green or red</param>
        public SignModel(int signId, int xPosition, int yPosition, RuleType type, int maxVelocity)
        {
            SignId = signId;

            SignWidth = 16;
            SignHeight = 16;

            XScaleFactor = 1;
            YScaleFactor = 1;

            switch (type)
            {
                case RuleType.Stopp:
                    ImagePath = "pack://application:,,,/Resources/Stopp.png";
                    break;
                case RuleType.Vorrang:
                    ImagePath = "pack://application:,,,/Resources/VorrangGeben.png";
                    break;
                case RuleType.Ampel:

                    // Overwrite the sign height because traffic lights are larger
                    SignHeight = 45;

                    if (maxVelocity < 1)
                    {
                        ImagePath = "pack://application:,,,/Resources/AmpelRot.png";
                    }
                    else
                    {
                        ImagePath = "pack://application:,,,/Resources/AmpelGruen.png";
                    }
                    break;
                case RuleType.Geschwindigkeit:
                    //ToDo: Eventuell dynamische Geschwindigkeitsanzeigen erstellen
                    ImagePath = "pack://application:,,,/Resources/Geschwindigkeitsbegrenzung.png";
                    break;
                default:
                    ImagePath = "pack://application:,,,/Resources/Stopp.png";
                    break;
            }

            // Calculate the position after the size is known
            XPosition = xPosition - SignWidth / 2;
            YPosition = yPosition - SignHeight / 2;
        }
       
        #endregion

    } // Class
} // Namespace
