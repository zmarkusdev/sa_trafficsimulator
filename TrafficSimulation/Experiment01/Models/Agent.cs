using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technics;

namespace Experiment01.Models
{
    class Agent : Model
    {
        private int _Xpos;
        public int Xpos
        {
            get
            {
                return _Xpos;
            }

            set
            {
                if (_Xpos != value)
                {
                    _Xpos = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int _Ypos;
        public int Ypos
        {
            get
            {
                return _Ypos;
            }

            set
            {
                if (_Ypos != value)
                {
                    _Ypos = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int _Rotation;
        public int Rotation
        {
            get
            {
                return _Rotation;
            }

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
            get
            {
                return _ImagePath;
            }

            set
            {
                if (_ImagePath != value)
                {
                    _ImagePath = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int _Width;
        public int Width
        {
            get
            {
                return _Width;
            }

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
            get
            {
                return _Height;
            }

            set
            {
                if (_Height != value)
                {
                    _Height = value;
                    RaisePropertyChanged();
                }
            }
        }

        public Agent(int x, int y, int rot, int type)
        {
            Xpos = x;
            Ypos = y;
            Rotation = rot;

            switch (type)
            {
                default:
                    break;// ImagePath = Properties.Resources.Car01;
            }

            Image img = Image.FromFile(ImagePath);
            Width = img.Width;
            Height = img.Height;
        }




    }
}
