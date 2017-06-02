using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Technics;

namespace RuleEngineUserInterface.Models
{
    public class Crossway : Model
    {
        private int _CrosswayId;
        public int CrosswayId
        {
            get { return _CrosswayId; }
            set
            {
                if (_CrosswayId != value)
                {
                    _CrosswayId = value;
                    RaisePropertyChanged();
                }
            }
        }

        private ObservableCollection<CrosswayLine> _CrosswayLines;
        public ObservableCollection<CrosswayLine> CrosswayLines
        {
            get { return _CrosswayLines; }
            set
            {
                if (_CrosswayLines != value)
                {
                    _CrosswayLines = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int CurrentCrosswayLine;

        private DispatcherTimer CrosswayTimer;

        public Crossway ()
        {
            CrosswayLines = new ObservableCollection<CrosswayLine>();
            CurrentCrosswayLine = 0;
            CrosswayTimer = new DispatcherTimer();
            CrosswayTimer.Tick += CrosswayTimer_TimeElapsed;
        }

     

        public void SaveCrossway(int id, List<Datamodel.CrosswayDirection> lines, IEnumerable<Datamodel.Rule> rules)
        {
            CrosswayId = id;

            foreach (Datamodel.CrosswayDirection singleLine in lines)
            {
                List<Datamodel.Rule> dependingRules = new List<Datamodel.Rule>();
                foreach (int singleRuleId in singleLine.concurrentGreen)
                {
                    dependingRules.AddRange(rules.Where(var => var.Id == singleRuleId));
                }

                /// Add the lines into the list
                CrosswayLines.Add(new CrosswayLine(singleLine.hightime, dependingRules));
            }

            /// Start the timer
            CrosswayTimer.Start();
        }


        private void CrosswayTimer_TimeElapsed(object sender, EventArgs e)
        {
            try
            {
                /// Stop the timer for save handling
                CrosswayTimer.Stop();

                if (CrosswayLines.Count > 1)
                {
                    /// Increase current active crossway line
                    CurrentCrosswayLine += 1;

                    /// Catch line overflow
                    if (CurrentCrosswayLine == CrosswayLines.Count)
                    {
                        CurrentCrosswayLine = 0;
                    }

                    /// Update all Crossways
                    for (int i = 0; i < CrosswayLines.Count; i++)
                    {
                        CrosswayLines[i].SetRules((i == CurrentCrosswayLine) ? false : true);
                    }
                    
                    /// Update the timer interval time
                    CrosswayTimer.Interval = TimeSpan.FromSeconds(CrosswayLines[CurrentCrosswayLine].HighTime);
                }
                /// Special case for only one traffic sign
                else
                {
                    if (CurrentCrosswayLine == 1)
                    {
                        CrosswayLines[0].SetRules(false);
                        CurrentCrosswayLine = 0;
                    }
                    else
                    {
                        CrosswayLines[0].SetRules(true);
                        CurrentCrosswayLine = 1;
                    }
                    
                    /// Update the timer interval time
                    CrosswayTimer.Interval = TimeSpan.FromSeconds(CrosswayLines[0].HighTime);
                }

                /// Start the timer again 
                CrosswayTimer.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    } // Class
} // Namespace
