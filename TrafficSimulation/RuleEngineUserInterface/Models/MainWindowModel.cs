using Technics;

namespace RuleEngineUserInterface.Models
{
    public class MainWindowModel : Model
    {

        private int _WindowHeight;
        /// <summary>
        /// Height of the main window
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
        /// Width of the main window
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


        public MainWindowModel()
        {
            WindowHeight = 350;
            WindowWidth = 700;
        }
    }
}
