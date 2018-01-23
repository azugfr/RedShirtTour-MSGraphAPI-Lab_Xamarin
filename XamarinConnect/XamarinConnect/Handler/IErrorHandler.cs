using System;
using System.Threading;
using System.Threading.Tasks;

namespace XamarinConnect.Handler
{
    public interface IErrorHandler
    {
        Task ErrorHandlerAsync(Exception ex, CancellationToken ct);

        Task<bool> ErrorHandlerWithRetryAsync(Exception ex, CancellationToken ct);
    }
}