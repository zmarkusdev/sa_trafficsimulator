using Experiment01.Models;
using Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using TiledSharp;

namespace Experiment01.ViewModels
{
    public class MainWindowViewModel
    {
        private DispatcherTimer timer;
        private IAgentRepository Agents;

        public MainWindowModel GUI { get; set; }

        public MainWindowViewModel()
        {
            /// Create Gui Variables (Bindings to GUI)
            GUI = new MainWindowModel();

            var map = new TmxMap("../../Resources\\TiledMap.tmx");

            /// Create AgentRepository with Factory
            Agents = AgentRepositoryFactory.CreateRepository();

            /// Set up the Timer for refreshing the GUI
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            /// Start the GUI actualization timer
            timer.Start();
        }

        /// <summary>
        /// This Timer Tick event refreshs the gui at every usage
        /// This is done by actualize all objects from the datamodel to the internal models
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e">not used</param>
        private void Timer_Tick(object sender, EventArgs e)
        {

            IEnumerable ags = Agents.GetAllAgents();
            foreach (Agent ag in ags)
            {
                //ag.
            }



        }
    }
}
