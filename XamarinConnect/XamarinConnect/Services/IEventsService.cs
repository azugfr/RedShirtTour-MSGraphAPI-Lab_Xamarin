using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinConnect.Models;

namespace XamarinConnect.Services
{
    public interface IEventsService
    {
        Task<List<ResultsItem>> GetMyEventsAsync();
    }
}
