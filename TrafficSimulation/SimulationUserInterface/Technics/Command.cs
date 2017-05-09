using Apex.MVVM;
using System;
using System.Windows.Input;

namespace Technics
{
    public class Command : ICommand
    {
        protected Action action = null;
        protected Action<object> parameterizedAction = null;
        private bool canExecute = false;

        public event EventHandler CanExecuteChanged;
        public event CancelCommandEventHandler Executing;
        public event CommandEventHandler Executed;

        public Command(Action action, bool canExecute = true)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public Command(Action<object> parameterizedAction, bool canExecute = true)
        {
            this.parameterizedAction = parameterizedAction;
            this.canExecute = canExecute;
        }

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

        protected void InvokeAction(object param)
        {
            Action theAction = action;
            Action<object> theParameterizedAction = parameterizedAction;

            /// Try to Invoke the Actions
            theAction?.Invoke();
            theParameterizedAction?.Invoke(param);
        }

        protected void InvokeExecuted(CommandEventArgs args)
        {
            Executed?.Invoke(this, args);
        }
        protected void InvokeExecuting(CancelCommandEventArgs args)
        {
            Executing?.Invoke(this, args);
        }

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
