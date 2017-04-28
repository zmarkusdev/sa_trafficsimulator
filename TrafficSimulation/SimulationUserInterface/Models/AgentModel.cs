﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Technics;

namespace SimulationUserInterface.Models
{
    public class AgentModel : Model
    {
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

        public AgentModel(int xPosition, int yPosition, double rotation, int agentType, int agentWidth, int agentHeight, double xScale, double yScale)
        {
            XPosition = xPosition - agentWidth / 2;
            YPosition = yPosition - agentHeight / 2;

            Rotation = rotation;

            AgentWidth = agentWidth;
            AgentHeight = agentHeight;

            XScaleFactor = xScale;
            YScaleFactor = yScale;

            switch (agentType)
            {
                case 0:
                    ImagePath = "pack://application:,,,/Resources/Car01.png";
                    break;
                default:
                    ImagePath = "pack://application:,,,/Resources/Car01.png";
                    break;
            }
        }

    } // Class
} // Namespace
