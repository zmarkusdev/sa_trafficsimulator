using Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Technics;
using VehicleDeactivatorLibrary;

namespace SimulationUserInterface.Models
{
    public class AgentModel : Model
    {

        private int _AgentId;
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

        public AgentModel(int agentId, int xPosition, int yPosition, double rotation, AgentType agentType, int agentWidth, int agentHeight, double xScale, double yScale, bool active = true)
        {
            AgentId = agentId;

            XPosition = xPosition - agentWidth * 15 / 2;
            YPosition = yPosition - agentHeight * 15 / 2;

            Rotation = rotation;

            AgentWidth = agentWidth * 15;
            AgentHeight = agentHeight * 15;

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

            AgentTestCommand = new Command(() => AgentTestCommandExecute());
        }

        public Command AgentTestCommand { get; }
        private void AgentTestCommandExecute()
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

    } // Class
} // Namespace
