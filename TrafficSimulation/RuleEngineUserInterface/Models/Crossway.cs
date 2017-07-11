using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Threading;
using Technics;

namespace RuleEngineUserInterface.Models
{

    /// <summary>
    /// Class holding the information of a crossway including several lines
    /// </summary>
    public class Crossway : Model
    {
        private int _CrosswayId;
        /// <summary>
        /// Id of the crossway
        /// </summary>
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
        /// <summary>
        /// Traffic lines that are combined in one crossway
        /// </summary>
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

        /// <summary>
        /// Step variable that signals the current active line
        /// </summary>
        private int CurrentCrosswayLine;

        /// <summary>
        /// Timer for updating the crossway (switch the phases)
        /// </summary>
        private DispatcherTimer CrosswayTimer;


        /// <summary>
        /// Default Constructor initializing the crosswayline list and the dispatcher timer
        /// </summary>
        public Crossway ()
        {
            CrosswayLines = new ObservableCollection<CrosswayLine>();
            CurrentCrosswayLine = 0;
            CrosswayTimer = new DispatcherTimer();
            CrosswayTimer.Tick += CrosswayTimer_TimeElapsed;
        }

     
        /// <summary>
        /// Saves the lines and rules of a crossway and starts the timer for updating it 
        /// </summary>
        /// <param name="id">Id of the crossway</param>
        /// <param name="lines">Single directions of the crossway</param>
        /// <param name="rules">List of all dynamic rules (traffic lights)</param>
        public void SaveCrossway(int id, List<Datamodel.CrosswayDirection> lines, IEnumerable<Datamodel.Rule> rules)
        {
            CrosswayId = id;

            foreach (Datamodel.CrosswayDirection singleLine in lines)
            {
                // Add the rules of a crossway line into a crosswayline object
                List<Datamodel.Rule> dependingRules = new List<Datamodel.Rule>();
                foreach (int singleRuleId in singleLine.concurrentGreen)
                {
                    dependingRules.AddRange(rules.Where(var => var.Id == singleRuleId));
                }

                // Add the lines into the list
                CrosswayLines.Add(new CrosswayLine(singleLine.hightime, dependingRules));
            }

            // Start the timer
            CrosswayTimer.Start();
        }


        /// <summary>
        /// Timer update which actualizes the crossways (switch from red to green or vice versa)
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e">not used</param>
        private void CrosswayTimer_TimeElapsed(object sender, EventArgs e)
        {
            try
            {
                // Stop the timer for save handling
                CrosswayTimer.Stop();

                if (CrosswayLines.Count > 1)
                {
                    // Increase current active crossway line
                    CurrentCrosswayLine += 1;

                    // Catch line overflow
                    if (CurrentCrosswayLine == CrosswayLines.Count)
                    {
                        CurrentCrosswayLine = 0;
                    }

                    // Update all Crossways
                    for (int i = 0; i < CrosswayLines.Count; i++)
                    {
                        CrosswayLines[i].SetRules((i == CurrentCrosswayLine) ? false : true);
                    }
                    
                    // Update the timer interval time
                    CrosswayTimer.Interval = TimeSpan.FromSeconds(CrosswayLines[CurrentCrosswayLine].HighTime);
                }
                // Special case for only one traffic sign
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
                    
                    // Update the timer interval time
                    CrosswayTimer.Interval = TimeSpan.FromSeconds(CrosswayLines[0].HighTime);
                }

                // Start the timer again 
                CrosswayTimer.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    } // Class
} // Namespace
