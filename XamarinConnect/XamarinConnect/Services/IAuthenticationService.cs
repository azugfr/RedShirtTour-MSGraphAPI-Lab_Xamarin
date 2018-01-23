using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Graph;

namespace XamarinConnect.Services
{
    public interface IAuthenticationService
    {
        GraphServiceClient GetAuthenticatedClient();
        Task<string> GetTokenForUserAsync();
        void SignOut();
    }
}
