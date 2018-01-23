using System;
using System.Windows.Input;

namespace XamarinConnect.Commands
{
    public interface IReverseCommand : ICommand
    {
        event EventHandler Executed;
        bool CanExecute();
        void Execute();
    }

    public interface IReverseCommand<T> : ICommand
    {
        event EventHandler<T> Executed;
        bool CanExecute(T parameter);
        void Execute(T parameter);
    }
}
