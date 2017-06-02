using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technics;

namespace RuleEngineUserInterface.Models
{
    public class CrosswayRepository : Model
    {

        private List<Crossway> _Crossways;
        public List<Crossway> Crossways
        {
            get { return _Crossways; }
            set
            {
                if (_Crossways != value)
                {
                    _Crossways = value;
                    RaisePropertyChanged();
                }
            }
        }


        public CrosswayRepository()
        {
            Crossways = new List<Crossway>();
        }

        public void SaveCrossways(IEnumerable<Datamodel.Crossway> crossways, IEnumerable<Datamodel.Rule> rules)
        {
            try
            {
                foreach (Datamodel.Crossway singleCrossway in crossways)
                {
                    Crossway tempCrossway = new Crossway();

                    tempCrossway.SaveCrossway(singleCrossway.Id, singleCrossway.greenphase, rules);

                    Crossways.Add(tempCrossway);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        
    } // Class
} // Namespace
