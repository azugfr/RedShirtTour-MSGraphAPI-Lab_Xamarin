using System;
using System.Windows.Input;

namespace XamarinConnect.Commands
{
    public class ReverseCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public event EventHandler<T> Executed;

        private readonly Action<T> _execute;

        public ReverseCommand(Action<T> execute = null)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Executed?.Invoke(this, (T)parameter);
            _execute?.Invoke((T)parameter);
        }
    }


    public class ReverseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public event EventHandler Executed;

        private readonly Action _execute;

        public ReverseCommand(Action execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Executed?.Invoke(this, EventArgs.Empty);
            _execute?.Invoke();
        }
    }

}
