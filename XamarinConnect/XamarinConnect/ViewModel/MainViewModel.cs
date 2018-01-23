using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using Microsoft.Graph;
using XamarinConnect.Commands;
using XamarinConnect.Models;
using XamarinConnect.Services;

namespace XamarinConnect.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private bool _isBusy;
        private GraphServiceClient GraphServiceClient { get; set; }
        private readonly IAuthenticationService _authenticationService;

        private User _user;
        public User User
        {
            get => _user;
            set => Set(ref _user, value);
        }

        private bool _isConnected;
        public bool IsConnected
        {
            get => _isConnected;
            set
            {
                Set(ref _isConnected, value);
                RaisePropertyChanged(nameof(SignBtn));
            }

        }

        public string SignBtn
        {
            get => IsConnected ? "SignOut" : "SignIn";
        }



        public MainViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            NavigateToSignInAuthCommand = new SyncCommand(ExecuteSignInSignOut);
            NavigateToSignInAuth = new ReverseCommand(null);
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set { Set(ref _isBusy, value); }
        }

        public async Task StartAsync()
        {
            try
            {
                IsBusy = true;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void ExecuteSignInSignOut()
        {
            if (!IsConnected)
            {
                await ExecuteSignIn();
            }
            else
            {
                SignOut();
            }
        }

        private async Task ExecuteSignIn()
        {
            try
            {
                GraphServiceClient = _authenticationService.GetAuthenticatedClient();
                User = await GraphServiceClient.Me.Request().GetAsync();
                IsConnected = true;
                await StartAsync();
            }
            catch (Exception e)
            {
                //TODO catch ex
            }
        }

        public void SignOut()
        {
            _authenticationService.SignOut();
            User = null;
            IsConnected = false;
        }

        public ICommand NavigateToSignInAuthCommand { get; }
        public ReverseCommand NavigateToSignInAuth { get; }
    }
}
