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

        public MainWindowModel()
        {
            WindowHeight = 600;
            WindowWidth = 800;

           
        }

        public void SetBackgroundInformation(char [] bytestream, int width, int height)
        {
            try
            {
                BackgroundMap = new string (bytestream);
                WindowWidth = width;
                WindowHeight = height;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
