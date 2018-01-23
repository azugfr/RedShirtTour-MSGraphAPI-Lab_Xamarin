using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using XamarinConnect.Handler;

namespace XamarinConnect.Commands
{
    public class AsyncCommand : IAsyncCommand
    {
        public event EventHandler CanExecuteChanged;

        private bool _isExecuting;
        private readonly Func<Task> _execute;
        private readonly Func<bool> _canExecute;
        private readonly IErrorHandler _errorHandler;
        private IReverseAsyncCommand executeNavigateToOilConsumption;

        public AsyncCommand(Func<Task> execute, Func<bool> canExecute = null, IErrorHandler errorHandler = null)
        {
            _execute = execute;
            _canExecute = canExecute;
            _errorHandler = errorHandler;
        }

        public AsyncCommand(IReverseAsyncCommand executeNavigateToOilConsumption)
        {
            this.executeNavigateToOilConsumption = executeNavigateToOilConsumption;
        }

        public bool CanExecute()
        {
            return !_isExecuting && (_canExecute?.Invoke() ?? true);
        }

        public async Task ExecuteAsync()
        {
            if (CanExecute())
            {
                try
                {
                    _isExecuting = true;
                    await _execute();
                }
                finally
                {
                    _isExecuting = false;
                }
            }

            RaiseCanExecuteChanged();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
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

    public class AsyncCommand<T> : IAsyncCommand<T>
    {
        public event EventHandler CanExecuteChanged;

        private bool _isExecuting;
        private readonly Func<T, Task> _execute;
        private readonly Func<T, bool> _canExecute;
        private readonly IErrorHandler _errorHandler;

        public AsyncCommand(Func<T, Task> execute, Func<T, bool> canExecute = null, IErrorHandler errorHandler = null)
        {
            _execute = execute;
            _canExecute = canExecute;
            _errorHandler = errorHandler;
        }

        public bool CanExecute(T parameter)
        {
            return !_isExecuting && (_canExecute?.Invoke(parameter) ?? true);
        }

        public async Task ExecuteAsync(T parameter)
        {
            if (CanExecute(parameter))
            {
                try
                {
                    _isExecuting = true;
                    await _execute(parameter);
                }
                finally
                {
                    _isExecuting = false;
                }
            }

            RaiseCanExecuteChanged();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
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
