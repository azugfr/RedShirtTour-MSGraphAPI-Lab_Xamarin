using System;

namespace XamarinConnect.Commands
{
    public interface IReverseAsyncCommand : IAsyncCommand
    {
        event EventHandler Executed;
    }

    public interface IReverseAsyncCommand<T> : IAsyncCommand<T>
    {
        event EventHandler<T> Executed;
    }
}
