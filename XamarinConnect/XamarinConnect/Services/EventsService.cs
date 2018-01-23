using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Graph;
using XamarinConnect.Models;

namespace XamarinConnect.Services
{
    public class EventsService : IEventsService
    {
        private readonly IAuthenticationService _authenticationService;

        public EventsService(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<List<ResultsItem>> GetMyEventsAsync()
        {
            GraphServiceClient graphClient = _authenticationService.GetAuthenticatedClient();
            List<ResultsItem> items = new List<ResultsItem>();

            IUserEventsCollectionPage events = await graphClient.Me.Events.Request().GetAsync();

            if (events?.Count > 0)
            {
                foreach (Event current in events)
                {
                    items.Add(new ResultsItem
                    {
                        Display = current.Subject,
                        Id = current.Id
                    });
                }
            }
            return items;
        }
    }
}
