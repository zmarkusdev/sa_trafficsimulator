using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationUserInterface.Models
{
    public class SignRepository
    {
        public ObservableCollection<SignModel> MapSigns { get; set; }

        public SignRepository()
        {
            MapSigns = new ObservableCollection<SignModel>();
        }

    }
}
