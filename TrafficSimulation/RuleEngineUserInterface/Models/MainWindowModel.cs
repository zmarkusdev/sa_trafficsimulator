using Technics;

namespace RuleEngineUserInterface.Models
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

        public MainWindowModel()
        {
            WindowHeight = 400;
            WindowWidth = 400;
        }
    }
}
