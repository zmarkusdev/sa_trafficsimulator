using System;
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

        private int _Width;
        public int Width
        {
            get { return _Width; }
            set
            {
                if (_Width != value)
                {
                    _Width = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int _Height;
        public int Height
        {
            get { return _Height; }
            set
            {
                if (_Height != value)
                {
                    _Height = value;
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

        public AgentModel(int x, int y, int rotation, int type, int width, int height)
        {
            X = x - width / 2;
            Y = y - height / 2;
            Rotation = rotation;

            Width = width;
            Height = height;

            switch (type)
            {
                case 0:
                    ImagePath = "pack://application:,,,/Resources/Car01.png";
                    break;
                default:
                    ImagePath = "pack://application:,,,/Resources/Car01.png";
                    break;
            }

        }

        public void ChangeAgentPictureSize(double widthfactor, double heightfactor)
        {
            Width = Convert.ToInt32(Math.Round(Width * widthfactor));
            Height = Convert.ToInt32(Math.Round(Height * heightfactor));
            X = Convert.ToInt32(Math.Round(X * widthfactor));
            Y = Convert.ToInt32(Math.Round(Y * heightfactor));
        }
    }
}
