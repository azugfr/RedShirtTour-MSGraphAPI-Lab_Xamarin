using System;
using System.Threading.Tasks;
using Microsoft.Graph;
using XamarinConnect.Models;

namespace XamarinConnect.ViewModel
{
    public class EventDetailViewModel : ViewModelBase
    {
        public class Parameter
        {
            public Event Event { get; set; }
        }

        private Event _eventItem;
        public Event EventItem
        {
            get => _eventItem;
            set => Set(ref _eventItem, value);
        }

        public EventDetailViewModel() : base()
        {
        }

        public override void Start(object parameterBase)
        {
            EventItem = ((Parameter)parameterBase).Event;
        }

        private Task Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
