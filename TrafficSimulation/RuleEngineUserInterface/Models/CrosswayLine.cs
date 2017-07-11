using Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Technics;

namespace RuleEngineUserInterface.Models
{
    public class CrosswayLine : Model
    {
        private int _HighTime;
        /// <summary>
        /// The time (int) of a green phase of the crossway line
        /// </summary>
        public int HighTime
        {
            get { return _HighTime; }
            set
            {
                if (_HighTime != value)
                {
                    _HighTime = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// List of rules that are combined in this green phase (e.q. opposit traffic lights)
        /// </summary>
        private List<Datamodel.Rule> Rules { get; set; }

        /// <summary>
        /// A Backup of ruleIds and maximum speed in order to get it back after setting it to 0 (red phase)
        /// </summary>
        private List<KeyValuePair<int, int>> BackupVelocity { get; set; }


        /// <summary>
        /// Constructor initializing the rules and the backup of the rule velocity
        /// </summary>
        /// <param name="highTime"></param>
        /// <param name="rules"></param>
        public CrosswayLine(int highTime, List<Datamodel.Rule> rules)
        {
            HighTime = highTime;
            Rules = new List<Datamodel.Rule>(rules);
            
            ///Backup the speed of the rules
            BackupVelocity = new List<KeyValuePair<int, int>>();
            Rules.ForEach(var => BackupVelocity.Add(new KeyValuePair<int, int>(var.Id, var.MaxVelocity)));
            
        }

        /// <summary>
        /// This function enables or disables a crossway line in order to signalize green or red
        /// </summary>
        /// <param name="enabled"></param>
        public void SetRules(bool enabled)
        {
            foreach (Datamodel.Rule singleRule in Rules)
            {
                /// Set the max allowed speed
                singleRule.MaxVelocity = enabled ? BackupVelocity.Where(var => var.Key == singleRule.Id).ToList().First().Value : 0;

                /// Update the backend
                RuleRepositoryFactory.CreateRepository().Update(singleRule);

                #if DEBUG
                    Console.WriteLine("Enable Rule {0} updated {1} with velocity {2}", singleRule.Id, enabled, singleRule.MaxVelocity);
                #endif
            }
        }
       
    } // Class
} // Namespace
