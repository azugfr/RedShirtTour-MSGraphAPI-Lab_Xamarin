using System.Windows.Input;

namespace XamarinConnect.Commands
{
    public interface ISyncCommand : ICommand
    {
        void Execute();
        bool CanExecute();
    }

    public interface ISyncCommand<in T> : ICommand
    {
        void Execute(T parameter);
        bool CanExecute(T parameter);
    }
}
