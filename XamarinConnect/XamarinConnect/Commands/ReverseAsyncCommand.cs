using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using XamarinConnect.Handler;

namespace XamarinConnect.Commands
{
    public class ReverseAsyncCommand : IReverseAsyncCommand
    {
        public event EventHandler CanExecuteChanged;
        public event EventHandler Executed;

        private bool _isExecuting;
        private readonly Func<Task> _execute;
        private readonly Func<bool> _canExecute;
        private readonly IErrorHandler _errorHandler;

        public ReverseAsyncCommand(Func<Task> execute = null, Func<bool> canExecute = null, IErrorHandler errorHandler = null)
        {
            _execute = execute;
            _canExecute = canExecute;
            _errorHandler = errorHandler;
        }

        public async Task ExecuteAsync()
        {
            if (CanExecute())
            {
                try
                {
                    _isExecuting = true;
                    RaiseExecuted();
                    var invoke = _execute?.Invoke();
                    if (invoke != null)
                        await invoke;
                }
                finally
                {
                    _isExecuting = false;
                }
            }

            RaiseCanExecuteChanged();
        }

        public bool CanExecute()
        {
            return !_isExecuting && (_canExecute?.Invoke() ?? true);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        protected void RaiseExecuted()
        {
            Executed?.Invoke(this, EventArgs.Empty);
        }

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        async void ICommand.Execute(object parameter)
        {
            await ExecuteAsync();
        }
    }

    public class ReverseAsyncCommand<T> : IReverseAsyncCommand<T>
    {
        public event EventHandler CanExecuteChanged;
        public event EventHandler<T> Executed;

        private bool _isExecuting;
        private readonly Func<T, Task> _execute;
        private readonly Func<T, bool> _canExecute;
        private readonly IErrorHandler _errorHandler;

        public ReverseAsyncCommand(Func<T, Task> execute = null, Func<T, bool> canExecute = null, IErrorHandler errorHandler = null)
        {
            _execute = execute;
            _canExecute = canExecute;
            _errorHandler = errorHandler;
        }

        public async Task ExecuteAsync(T parameter)
        {
            if (CanExecute(parameter))
            {
                try
                {
                    _isExecuting = true;
                    RaiseExecuted(parameter);
                    var invoke = _execute?.Invoke(parameter);
                    if (invoke != null)
                        await invoke;
                }
                finally
                {
                    _isExecuting = false;
                }
            }

            RaiseCanExecuteChanged();
        }

        public bool CanExecute(T parameter)
        {
            return !_isExecuting && (_canExecute?.Invoke(parameter) ?? true);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        protected void RaiseExecuted(T parameter)
        {
            Executed?.Invoke(this, parameter);
        }

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute((T)parameter);
        }

        async void ICommand.Execute(object parameter)
        {
            await ExecuteAsync((T)parameter);
        }
    }
}
