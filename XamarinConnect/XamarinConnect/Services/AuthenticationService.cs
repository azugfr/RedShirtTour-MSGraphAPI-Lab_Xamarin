using Microsoft.Graph;
using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using System.Net.Http;
using System.Threading;
using Xamarin.Forms;

namespace XamarinConnect.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private const string Url = "https://graph.microsoft.com/v1.0";
        public DateTimeOffset Expiration { get; set; }
        public string TokenForUser { get; set; }
        private GraphServiceClient graphClient = null;

        public GraphServiceClient GetAuthenticatedClient()
        {
            if (graphClient == null)
            {
                try
                {

                    graphClient = new GraphServiceClient(
                        Url,
                        new DelegateAuthenticationProvider(
                            async (requestMessage) =>
                            {
                                var token = await GetTokenForUserAsync().ConfigureAwait(false);
                                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);

                            }));
                    return graphClient;
                }

                catch (Exception ex)
                {
                    Debug.WriteLine("Could not create a graph client: " + ex.Message);
                }
            }

            return graphClient;
        }

        public async Task<string> GetTokenForUserAsync()
        {
            if (TokenForUser == null)
            {
                if (Application.Current.Properties.ContainsKey("tokenForUser") && Application.Current.Properties.ContainsKey("expiresOn") && Application.Current.Properties.ContainsKey("expiresOn"))
                {
                    TokenForUser = Application.Current.Properties["tokenForUser"] as string;
                    var expiresOn = Application.Current.Properties["expiresOn"];
                    if (expiresOn != null)
                        Expiration = (System.DateTimeOffset)expiresOn;
                }
            }
            if (Expiration <= DateTimeOffset.UtcNow.AddMinutes(5))
            {

                AuthenticationResult authResult = await App.IdentityClientApp.AcquireTokenAsync(App.Scopes, App.UiParent);


                TokenForUser = authResult.AccessToken;
                Expiration = authResult.ExpiresOn;

                Application.Current.Properties["tokenForUser"] = TokenForUser;
                Application.Current.Properties["expiresOn"] = Expiration;
                await Application.Current.SavePropertiesAsync();
            }

            return TokenForUser;
        }

        public void SignOut()
        {
            foreach (var user in App.IdentityClientApp.Users)
            {
                App.IdentityClientApp.Remove(user);
            }
            graphClient = null;
            TokenForUser = null;
            Expiration = new DateTimeOffset();
            Application.Current.Properties.Clear();
            Application.Current.SavePropertiesAsync();
        }
    }
}
