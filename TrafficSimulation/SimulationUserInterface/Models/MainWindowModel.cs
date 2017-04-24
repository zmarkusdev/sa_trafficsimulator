using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public MainWindowModel()
        {
            WindowHeight = 600;
            WindowWidth = 800;
        }

    }
}
