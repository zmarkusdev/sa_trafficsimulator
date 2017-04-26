using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Technics;

namespace SimulationUserInterface.Models
{
    public class MainWindowModel : Model
    {

        private int _WindowHeight;
        public int WindowHeight
        {
            get { return _WindowHeight; }
            set
            {
                if (_WindowHeight != value)
                {
                    _WindowHeight = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int _WindowWidth;
        public int WindowWidth
        {
            get { return _WindowWidth; }
            set
            {
                if (_WindowWidth != value)
                {
                    _WindowWidth = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _BackgroundMap;
        public string BackgroundMap
        {
            get { return _BackgroundMap; }
            set
            {
                if (_BackgroundMap != value)
                {
                    _BackgroundMap = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int _BackgroundMapHeight;
        public int BackgroundMapHeight
        {
            get { return _BackgroundMapHeight; }
            set
            {
                if (_BackgroundMapHeight != value)
                {
                    _BackgroundMapHeight = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int _BackgroundMapWidth;
        public int BackgroundMapWidth
        {
            get { return _BackgroundMapWidth; }
            set
            {
                if (_BackgroundMapWidth != value)
                {
                    _BackgroundMapWidth = value;
                    RaisePropertyChanged();
                }
            }
        }



        public MainWindowModel()
        {
            WindowHeight = 1000;
            WindowWidth = 1000;
        }

        public void SetBackgroundInformation(char [] bytestream, int width, int height)
        {
            try
            {
                BackgroundMap = new string (bytestream);
                BackgroundMapWidth = width;
                BackgroundMapHeight = height;
                WindowWidth = width;
                WindowHeight = height;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetImageFactor(out double WidthFactor, out double HeightFactor)
        {
            try
            {
                WidthFactor = (double)WindowWidth / (((double)BackgroundMapWidth == 0) ? 1.0 : (double)BackgroundMapWidth);
                HeightFactor = (double)WindowHeight / (((double)BackgroundMapHeight == 0) ? 1.0 : (double)BackgroundMapHeight);
                
            }
            catch (Exception ex)
            {
                WidthFactor = 1;
                HeightFactor = 1;
                Console.WriteLine(ex.Message);
            }
        }
    }
}
