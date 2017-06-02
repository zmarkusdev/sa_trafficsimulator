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

        private List<Datamodel.Rule> Rules { get; set; }
        
        private List<KeyValuePair<int, int>> BackupVelocity { get; set; }

        public CrosswayLine(int highTime, List<Datamodel.Rule> rules)
        {
            HighTime = highTime;
            Rules = new List<Datamodel.Rule>(rules);
            
            BackupVelocity = new List<KeyValuePair<int, int>>();
            Rules.ForEach(var => BackupVelocity.Add(new KeyValuePair<int, int>(var.Id, var.MaxVelocity)));

        
            SaveSettings = new Command(() => SaveSettingsExecute());
        }

        public void SetRules(bool enabled)
        {
            foreach (Datamodel.Rule singleRule in Rules)
            {

                singleRule.MaxVelocity = enabled ? BackupVelocity.Where(var => var.Key == singleRule.Id).ToList().First().Value : 0;

                RuleRepositoryFactory.CreateRepository().Update(singleRule);

                Console.WriteLine("Enable Rule {0} updated {1} with velocity {2}", singleRule.Id, enabled, singleRule.MaxVelocity);
            }
        }

        public Command SaveSettings { get; }
        private void SaveSettingsExecute()
        {
            Console.WriteLine("Settings saved");
            //ToDo: Settings an Backend übermitteln
        }


        public List<Datamodel.Rule> DeepCopy(List<Datamodel.Rule> origin)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, origin);

            ms.Position = 0;
            return (List<Datamodel.Rule>)bf.Deserialize(ms);
        }

    }
}
