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

        public CrosswayRepository CrosswayRepository;

        public MainWindowViewModel()
        {
            UserInterfaceModel = new MainWindowModel();
            
            CrosswayRepository = new CrosswayRepository();

            
            CrosswayRepository.SaveCrossways(CrosswayRepositoryFactory.CreateRepository().GetAll(), 
                                             RuleRepositoryFactory.CreateRepository().GetDynamicRules());


            ExitCommand = new Command(() => ExitCommandExecute());
        }

        public Command ExitCommand { get; }
        private void ExitCommandExecute()
        {
            Environment.Exit(0);
        }

    }
}
