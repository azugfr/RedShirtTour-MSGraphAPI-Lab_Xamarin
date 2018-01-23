using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Graph;
using XamarinConnect.Models;

namespace XamarinConnect.Services
{
    public interface IGroupsService
    {
        Task<List<ResultsItem>> GetGroupsAsync();
        Task<List<Event>> GetGroupEventsAsync(string id);
        Task<List<Event>> GetGroupEventsAsync(string id, string orderResult);
    }
}
