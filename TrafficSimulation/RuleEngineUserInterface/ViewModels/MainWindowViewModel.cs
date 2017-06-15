using Datamodel;
using Repositories;
using RuleEngineUserInterface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technics;

namespace RuleEngineUserInterface.ViewModels
{
    public class MainWindowViewModel
    {
        /// <summary>
        /// Main Model with User Interface bindings for static use
        /// </summary>
        public MainWindowModel UserInterfaceModel { get; set; }

        /// <summary>
        /// Binding to the Repository of Crossways which are loaded from the global Repository and
        /// bound in a object hierarchy that allowes it to visualize them
        /// </summary>
        public CrosswayRepository CrosswayRepository { get; set; }


        public MainWindowViewModel()
        {
            /// Load GUI Variables
            UserInterfaceModel = new MainWindowModel();
            
            /// Load Crossway
            CrosswayRepository = new CrosswayRepository();
            
            /// Save the crossways and rules in the local repository
            CrosswayRepository.SaveCrossways(CrosswayRepositoryFactory.CreateRepository().GetAll(), 
                                             RuleRepositoryFactory.CreateRepository().GetDynamicRules());


            /// Initialize commands
            ExitCommand = new Command(() => ExitCommandExecute());
        }

        public Command ExitCommand { get; }
        /// <summary>
        /// ExitCommand Function that is called if the ExitCommand is executed
        /// This function closes the program
        /// </summary>
        private void ExitCommandExecute()
        {
            Environment.Exit(0);
        }

    }
}
