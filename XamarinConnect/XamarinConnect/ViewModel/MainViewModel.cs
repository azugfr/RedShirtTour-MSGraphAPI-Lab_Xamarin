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
        private readonly IGroupsService _groupsService;
        private readonly IEventsService _eventsService;

        private Event _eventSelected;
        public Event EventSelected
        {
            get => _eventSelected;
            set => Set(ref _eventSelected, value);
        }

        public IAsyncCommand SelectEventCommand { get; }
        public IReverseAsyncCommand<Event> NavigateToEventCommand { get; set; }

        private List<Event> _events;
        public List<Event> Events
        {
            get => _events;
            private set => Set(ref _events, value);
        }

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



        public MainViewModel(IAuthenticationService authenticationService, IGroupsService groupsService, IEventsService eventsService)
        {
            _authenticationService = authenticationService;
            _groupsService = groupsService;
            _eventsService = eventsService;
            NavigateToSignInAuthCommand = new SyncCommand(ExecuteSignInSignOut);
            NavigateToSignInAuth = new ReverseCommand(null);
            SelectEventCommand = new AsyncCommand(ExecuteSelectEvent);
        }

        private async Task ExecuteSelectEvent()
        {
            if (EventSelected != null)
            {
                await NavigateToEventCommand?.ExecuteAsync(EventSelected);
            }
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
                var groups = await _groupsService.GetGroupsAsync();
                Events = await _groupsService.GetGroupEventsAsync(groups[0].Id.ToString());
                //var events = await _eventsService.GetMyEventsAsync();
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
            //NavigateToSignInAuth.Execute(null);
        }

        public void SignOut()
        {
            _authenticationService.SignOut();
            Events = null;
            User = null;
            IsConnected = false;
        }

        public ICommand NavigateToSignInAuthCommand { get; }
        public ReverseCommand NavigateToSignInAuth { get; }
    }
}
