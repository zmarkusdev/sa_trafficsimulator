using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technics;

namespace SimulationUserInterface.Models
{
    public class AgentModel : Model
    {
        private int _X;
        public int X
        {
            get { return _X; }
            set
            {
                if (_X != value)
                {
                    _X = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int _Y;
        public int Y
        {
            get { return _Y; }
            set
            {
                if (_Y != value)
                {
                    _Y = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int _Rotation;
        public int Rotation
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

        public AgentModel(int x, int y, int rotation)
        {
            X = x;
            Y = y;
            Rotation = rotation;
        }
    }
}
