using ITransitionFinalAPI.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FrontendAppCollections.Services.Interfaces
{
    public interface IUserCollectorService
    {
        Task<List<UserCollector>> GetUsersAsync();
        Task AddToAdminAsync(int userId);
        Task BlockUserAsync(int userId);
        Task DeleteUserAsync(int userId);
    }
}
