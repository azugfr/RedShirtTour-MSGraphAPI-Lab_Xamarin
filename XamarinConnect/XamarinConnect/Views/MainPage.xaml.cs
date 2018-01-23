using Microsoft.Graph;
using System;
using XamarinConnect.ViewModel;
using XamarinConnect.Models;
using Xamarin.Forms;
using XamarinConnect.Commands;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;

namespace XamarinConnect.Views
{
    [XamlCompilation(Xamarin.Forms.Xaml.XamlCompilationOptions.Compile)]
    public partial class MainPage : BaseContentPage<MainViewModel>
    {
        private static GraphServiceClient graphClient = null;

        public MainPage() : base()
        {
            InitializeComponent();
            ViewModel.NavigateToEventCommand = new ReverseAsyncCommand<Event>(this.ExecuteNavigateToEvent);

        }

        private async Task ExecuteNavigateToEvent(Event eventItem)
        {
            var EventSelection = new EventDetail(eventItem);

            //GroupSelected.SelectedItem = null;

            await Navigation.PushAsync(EventSelection);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.NavigateToSignInAuth.Executed += OnNavigateToToSignInAuthExecuted;
            InfoText.Text = "";
        }

        private void OnNavigateToToSignInAuthExecuted(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new QuestionPage());
        }

        protected override void OnViewModelPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            switch (propertyName)
            {
                case nameof(ViewModel.IsConnected):
                    Connected();
                    break;
            }
        }

        private void Connected()
        {
            EmailAddress.IsVisible = ViewModel.IsConnected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectEventCommand?.ExecuteAsync();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ViewModel.NavigateToSignInAuth.Executed -= OnNavigateToToSignInAuthExecuted;
        }
    }
}
