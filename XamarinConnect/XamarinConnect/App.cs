using Microsoft.Identity.Client;
using Xamarin.Forms;
using GalaSoft.MvvmLight.Ioc;
using XamarinConnect.Services;
using XamarinConnect.ViewModel;
using XamarinConnect.Views;

namespace XamarinConnect
{
    public class App : Application
    {

        public static PublicClientApplication IdentityClientApp;
        public static string ClientID = "<Application id>";
        public static string RedirectUri = "msal" + ClientID + "://auth";
        public static string[] Scopes = { };
        public static string Username = string.Empty;
        public static string UserEmail = string.Empty;


        public static UIParent UiParent;
        public App()
        {
            InitializeIoc();
            IdentityClientApp = new PublicClientApplication(ClientID);
            MainPage = new NavigationPage(new MainPage());
        }

        private void InitializeIoc()
        {
            SimpleIoc.Default.Register<MainViewModel>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
