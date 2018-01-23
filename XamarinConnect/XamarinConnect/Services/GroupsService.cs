using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.Graph;
using XamarinConnect.Models;

namespace XamarinConnect.Services
{
    public class GroupsService : IGroupsService
    {
        private readonly IAuthenticationService _authenticationService;

        public GroupsService(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<List<ResultsItem>> GetGroupsAsync()
        {
            GraphServiceClient graphClient = _authenticationService.GetAuthenticatedClient();
            List<ResultsItem> items = new List<ResultsItem>();

            IGraphServiceGroupsCollectionPage groups = await graphClient.Groups.Request().GetAsync();

            if (groups?.Count > 0)
            {
                foreach (Group group in groups)
                {
                    items.Add(new ResultsItem
                    {
                        Display = group.DisplayName,
                        Id = group.Id
                    });
                }
            }
            return items;
        }

        public async Task<List<Event>> GetGroupEventsAsync(string id)
        {
            return await GetGroupEventsAsync(id, "Subject");
        }
        public async Task<List<Event>> GetGroupEventsAsync(string id, string orderResult)
        {
            GraphServiceClient graphClient = _authenticationService.GetAuthenticatedClient();
            List<Event> items = new List<Event>();

            // Get the group.
            var events = await graphClient.Groups[id].Calendar.Events.Request().OrderBy(orderResult).GetAsync();

            if (events != null)
            {
                foreach (Event eventCalendar in events)
                {
                    items.Add(eventCalendar);
                }
            }
            return items;
        }
    }
}
