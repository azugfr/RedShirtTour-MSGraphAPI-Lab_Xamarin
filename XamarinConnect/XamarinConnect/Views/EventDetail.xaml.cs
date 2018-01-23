using Microsoft.Graph;
using Xamarin.Forms.Xaml;
using XamarinConnect.Models;
using XamarinConnect.ViewModel;

namespace XamarinConnect.Views
{
    [XamlCompilation(Xamarin.Forms.Xaml.XamlCompilationOptions.Compile)]
    public partial class EventDetail : BaseContentPage<EventDetailViewModel>
    {
        public EventDetail() : base()
        {

        }

        public EventDetail(Event eventItem) : base()
        {
            InitializeComponent();
            _parameter = new EventDetailViewModel.Parameter { Event = eventItem };
        }
    }
}
