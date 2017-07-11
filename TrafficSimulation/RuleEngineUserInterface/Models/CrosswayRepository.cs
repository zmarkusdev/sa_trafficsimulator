using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Technics;

namespace RuleEngineUserInterface.Models
{
    public class CrosswayRepository : Model
    {

        private ObservableCollection<Crossway> _Crossways;
        /// <summary>
        /// Collection of Crossways that can be dynamically updated in the gui
        /// </summary>
        public ObservableCollection<Crossway> Crossways
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


        /// <summary>
        /// Default constructor initializing the crossway list
        /// </summary>
        public CrosswayRepository()
        {
            Crossways = new ObservableCollection<Crossway>();
        }

        /// <summary>
        /// This function saves the crossways that are stored in the backend in Crossway and Rules and creates
        /// </summary>
        /// <param name="crossways">An IEnumerable that contains the binding of different dynamic rules</param>
        /// <param name="rules">An IEnumerable of dynamic rules</param>
        public void SaveCrossways(IEnumerable<Datamodel.Crossway> crossways, IEnumerable<Datamodel.Rule> rules)
        {
            try
            {
                foreach (Datamodel.Crossway singleCrossway in crossways)
                {
                    ///Create a temporary crossway and initialize it
                    Crossway tempCrossway = new Crossway();
                    tempCrossway.SaveCrossway(singleCrossway.Id, singleCrossway.greenphase, rules);

                    /// Save the temporary crossway in the list
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
