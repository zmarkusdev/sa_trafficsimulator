using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technics;

namespace SimulationUserInterface.Models
{
    public class EdgeModel : Model
    {
        private int _X1Position;
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

        public EdgeModel(int x1pos, int y1pos, int x2pos, int y2pos, double xscale, double yscale)
        {
            X1Position = x1pos;
            Y1Position = y1pos;
            X2Position = x2pos;
            Y2Position = y2pos;
            XScaleFactor = xscale;
            YScaleFactor = yscale;
        }


    }
}
