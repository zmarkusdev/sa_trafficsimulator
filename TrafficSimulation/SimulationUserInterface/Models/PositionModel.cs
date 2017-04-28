using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technics;

namespace SimulationUserInterface.Models
{
    public class PositionModel : Model
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

        public PositionModel(int xpos, int ypos, double xscale, double yscale)
        {
            XPosition = xpos;
            YPosition = ypos;
            XScaleFactor = xscale;
            YScaleFactor = yscale;
        }

    }
}
