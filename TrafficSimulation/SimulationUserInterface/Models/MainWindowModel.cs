using System;
using Technics;

namespace SimulationUserInterface.Models
{
    public class MainWindowModel : Model
    {

        #region ----- Variables

        private int _WindowHeight;
        /// <summary>
        /// Current window height
        /// </summary>
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
        /// <summary>
        /// Current window width
        /// </summary>
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
        /// <summary>
        /// Background map
        /// </summary>
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
        /// <summary>
        /// Heigth of the background map
        /// </summary>
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
        /// <summary>
        /// Width of the background map
        /// </summary>
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

        private bool _NetEnabled;
        /// <summary>
        /// Flag that shows/hide the positions and edges of the street map
        /// </summary>
        public bool NetEnabled
        {
            get { return _NetEnabled; }
            set
            {
                if (_NetEnabled != value)
                {
                    _NetEnabled = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion



        #region ----- Constructor

        /// <summary>
        /// Default constructor which sets the image size of the application for the first time
        /// </summary>
        public MainWindowModel()
        {
            WindowHeight = 900;
            WindowWidth = 1400;

            NetEnabled = false;

            CreatePoint = new Command((var) => CreatePointExecute(var));
        }

        #endregion


        #region ----- Public functions

        /// <summary>
        /// Sets the Background information for a new background image
        /// </summary>
        /// <param name="bytestream">Base64 encoded background map image</param>
        /// <param name="width">With of the background map image</param>
        /// <param name="height">Height of the background map image</param>
        public void SetBackgroundInformation(char [] bytestream, int width, int height)
        {
            try
            {
                /// The base64 stream has to be decoded into a string for the wpf gui
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

        /// <summary>
        /// Returns the new image resize factors for x and y if the window is resized by the user
        /// </summary>
        /// <param name="WidthFactor">output parameter: with factor</param>
        /// <param name="HeightFactor">output parameter: heiht factor</param>
        public void GetImageFactor(out double WidthFactor, out double HeightFactor)
        {
            try
            {
                ///Calculate the factors with the information of the map and the window and perform a save 0-division
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

        #endregion



        public Command CreatePoint { get; }
        private void CreatePointExecute(object parameter)
        {
            
            Console.WriteLine("Click");
        }

        
    }
}
