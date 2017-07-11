using Apex.MVVM;
using System;
using System.Windows.Input;

namespace Technics
{

    /// <summary>
    /// Class for enabling command binding from UI to code
    /// </summary>
    public class Command : ICommand
    {

        /// <summary>
        /// Command action without parameter
        /// </summary>
        protected Action action = null;
        /// <summary>
        /// Command action with parameter
        /// </summary>
        protected Action<object> parameterizedAction = null;
        private bool canExecute = false;

        /// <summary>
        /// Event for the CanExecute property
        /// </summary>
        public event EventHandler CanExecuteChanged;
        /// <summary>
        /// Event for the Executing property
        /// </summary>
        public event CancelCommandEventHandler Executing;
        /// <summary>
        /// Event for the Executed property
        /// </summary>
        public event CommandEventHandler Executed;

        /// <summary>
        /// Constructor binding a function to the command
        /// </summary>
        /// <param name="action"></param>
        /// <param name="canExecute"></param>
        public Command(Action action, bool canExecute = true)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Constructor binding a function including a parameter to the command
        /// </summary>
        /// <param name="parameterizedAction"></param>
        /// <param name="canExecute"></param>
        public Command(Action<object> parameterizedAction, bool canExecute = true)
        {
            this.parameterizedAction = parameterizedAction;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Function to check if the command is executeable
        /// </summary>
        public bool CanExecute
        {
            get { return canExecute; }
            set
            {
                if (canExecute != value)
                {
                    canExecute = value;
                    CanExecuteChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            return canExecute;
        }
        void ICommand.Execute(object parameter)
        {
            this.DoExecute(parameter);
        }

        /// <summary>
        /// Invoke action event
        /// </summary>
        /// <param name="param"></param>
        protected void InvokeAction(object param)
        {
            Action theAction = action;
            Action<object> theParameterizedAction = parameterizedAction;

            // Try to Invoke the Actions
            theAction?.Invoke();
            theParameterizedAction?.Invoke(param);
        }

        /// <summary>
        /// Invoke Executed event
        /// </summary>
        /// <param name="args"></param>
        protected void InvokeExecuted(CommandEventArgs args)
        {
            Executed?.Invoke(this, args);
        }
        /// <summary>
        /// Invoke Executing event
        /// </summary>
        /// <param name="args"></param>
        protected void InvokeExecuting(CancelCommandEventArgs args)
        {
            Executing?.Invoke(this, args);
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="param"></param>
        public virtual void DoExecute(object param)
        {
            CancelCommandEventArgs args = new CancelCommandEventArgs() { Parameter = param, Cancel = false };
            InvokeExecuting(args);

            if (args.Cancel)
            {
                return;
            }

            InvokeAction(param);

            InvokeExecuted(new CommandEventArgs() { Parameter = param });
        }
    }
}
