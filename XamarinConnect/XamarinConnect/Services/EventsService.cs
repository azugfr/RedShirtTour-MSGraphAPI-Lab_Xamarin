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
            throw new NotImplementedException();
        }
    }
}
