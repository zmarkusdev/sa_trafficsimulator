using Datamodel;
using System;
using Technics;
using VehicleDeactivatorLibrary;

namespace SimulationUserInterface.Models
{

    /// <summary>
    /// Class containing the information fo a Agent including the ability to bind it to the UI
    /// </summary>
    public class AgentModel : Model
    {

        #region ----- Variables

        private int _AgentId;
        /// <summary>
        /// ID of an agent with that he can be identified
        /// Is creaated form backend
        /// </summary>
        public int AgentId
        {
            get { return _AgentId; }
            set
            {
                if (_AgentId != value)
                {
                    _AgentId = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int _XPosition;
        /// <summary>
        /// Current XPosition of the agent on the x-axis in pixel
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
        /// Current YPosition of the agent on the y-axis in pixel
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
        /// is for resizing the agents on the map after the windowsize is changed
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
        /// is for resizing the agents on the map after the windowsize is changed
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

        private int _AgentWidth;
        /// <summary>
        /// With of the agent in pixel
        /// </summary>
        public int AgentWidth
        {
            get { return _AgentWidth; }
            set
            {
                if (_AgentWidth != value)
                {
                    _AgentWidth = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int _AgentHeight;
        /// <summary>
        /// Height of the agent in pixel
        /// </summary>
        public int AgentHeight
        {
            get { return _AgentHeight; }
            set
            {
                if (_AgentHeight != value)
                {
                    _AgentHeight = value;
                    RaisePropertyChanged();
                }
            }
        }

        private double _Rotation;
        /// <summary>
        /// Current rotation of the agent
        /// is calculated through the line on which the agent currently lies
        /// </summary>
        public double Rotation
        {
            get { return _Rotation; }
            set
            {
                if (_Rotation != value)
                {
                    _Rotation = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _ImagePath;
        /// <summary>
        /// Path of the image for showing the agent on the UI
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
        /// Constructor which calaculates the positions/rotation/with and selects a picuture for the view
        /// </summary>
        /// <param name="agentId">ID of the agent</param>
        /// <param name="xPosition">Original x-position where the agent should be placed on the screen</param>
        /// <param name="yPosition">Original y-position where the agent should be placed on the screen</param>
        /// <param name="rotation">Calculated rotation of the client</param>
        /// <param name="agentType">Type of the client (AgentType enum from AgentRepository)</param>
        /// <param name="agentWidth">With of the client given from backend</param>
        /// <param name="agentHeight">Height of the client given from backend</param>
        /// <param name="xScale">Calculated x-scale factor of the window</param>
        /// <param name="yScale">Calculated y-scale factor of the window</param>
        /// <param name="active">Flag that shows if the client is driving (true) or damaged (false)</param>
        public AgentModel(int agentId, int xPosition, int yPosition, double rotation, AgentType agentType, int agentWidth, int agentHeight, double xScale, double yScale, bool active = true)
        {
            AgentId = agentId;

            
            Rotation = rotation;

            AgentWidth = agentWidth;
            AgentHeight = agentHeight;

            XPosition = xPosition - agentWidth / 2;
            YPosition = yPosition - agentHeight / 2;


            XScaleFactor = xScale;
            YScaleFactor = yScale;

            if (active)
            {

                switch (agentType)
                {
                    case AgentType.Car01:
                        ImagePath = "pack://application:,,,/Resources/Car01.png";
                        break;
                    case AgentType.Car02:
                        ImagePath = "pack://application:,,,/Resources/Car02.png";
                        break;
                    case AgentType.Lkw01:
                        ImagePath = "pack://application:,,,/Resources/Lkw01.png";
                        break;
                    case AgentType.Lkw02:
                        ImagePath = "pack://application:,,,/Resources/Lkw01.png";
                        break;
                    default:
                        ImagePath = "pack://application:,,,/Resources/Car03.png";
                        break;
                }
            }
            else
            {
                switch (agentType)
                {
                    case AgentType.Car01:
                    case AgentType.Car02:
                        ImagePath = "pack://application:,,,/Resources/Car00.png";
                        break;
                    case AgentType.Lkw01:
                    case AgentType.Lkw02:
                        ImagePath = "pack://application:,,,/Resources/Lkw00.png";
                        break;
                    default:
                        ImagePath = "pack://application:,,,/Resources/Car00.png";
                        break;
                }
            }

            // Command binding for catching a click on a client
            AgentClickCommand = new Command(() => AgentClickCommandExecute());
        }

        /// <summary>
        /// Constructor which calaculates the positions/rotation/with and selects a picuture for the view
        /// </summary>
        /// <param name="agentId">ID of the agent</param>
        /// <param name="xPosition">Original x-position where the agent should be placed on the screen</param>
        /// <param name="yPosition">Original y-position where the agent should be placed on the screen</param>
        /// <param name="rotation">Calculated rotation of the client</param>
        /// <param name="agentType">Type of the client (AgentType enum from AgentRepository)</param>
        /// <param name="agentWidth">With of the client given from backend</param>
        /// <param name="agentHeight">Height of the client given from backend</param>
        /// <param name="active">Flag that shows if the client is driving (true) or damaged (false)</param>
        public AgentModel(int agentId, int xPosition, int yPosition, double rotation, AgentType agentType, int agentWidth, int agentHeight, bool active = true)
        {
            AgentId = agentId;


            Rotation = rotation;

            AgentWidth = agentWidth;
            AgentHeight = agentHeight;

            XPosition = xPosition - agentWidth / 2;
            YPosition = yPosition - agentHeight / 2;


            XScaleFactor = 1;
            YScaleFactor = 1;

            if (active)
            {

                switch (agentType)
                {
                    case AgentType.Car01:
                        ImagePath = "pack://application:,,,/Resources/Car01.png";
                        break;
                    case AgentType.Car02:
                        ImagePath = "pack://application:,,,/Resources/Car02.png";
                        break;
                    case AgentType.Lkw01:
                        ImagePath = "pack://application:,,,/Resources/Lkw01.png";
                        break;
                    case AgentType.Lkw02:
                        ImagePath = "pack://application:,,,/Resources/Lkw01.png";
                        break;
                    default:
                        ImagePath = "pack://application:,,,/Resources/Car03.png";
                        break;
                }
            }
            else
            {
                switch (agentType)
                {
                    case AgentType.Car01:
                    case AgentType.Car02:
                        ImagePath = "pack://application:,,,/Resources/Car00.png";
                        break;
                    case AgentType.Lkw01:
                    case AgentType.Lkw02:
                        ImagePath = "pack://application:,,,/Resources/Lkw00.png";
                        break;
                    default:
                        ImagePath = "pack://application:,,,/Resources/Car00.png";
                        break;
                }
            }

            // Command binding for catching a click on a client
            AgentClickCommand = new Command(() => AgentClickCommandExecute());
        }

        #endregion



        #region ----- Commands


        /// <summary>
        /// Command that binds the click on a agent to the code
        /// </summary>
        public Command AgentClickCommand { get; }
        /// <summary>
        /// Command event execute function which sends the clientId to a queue 
        /// for enabling or disabling vehicles (damage them)
        /// </summary>
        private void AgentClickCommandExecute()
        {
            try
            {
                MessageSender sender = new MessageSender();
                sender.ToggleVehicle(this.AgentId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Event executed at agent " + AgentId);
        }

        #endregion

    } // Class
} // Namespace
