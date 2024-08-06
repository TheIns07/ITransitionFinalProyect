using FrontendAppCollections.Services.Interfaces;
using ITransitionFinalAPI.Models;
namespace FrontendAppCollections.Services
{
    public class UserCollectorService : IUserCollectorService
    {
        private readonly HttpClient _httpClient;

        public UserCollectorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UserCollector>> GetUsersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<UserCollector>>("api/users"); // Cambia la URL según sea necesario
        }

        public async Task AddToAdminAsync(int userId)
        {
            await _httpClient.PostAsJsonAsync($"api/users/add-admin/{userId}", null); // Cambia la URL según sea necesario
        }

        public async Task BlockUserAsync(int userId)
        {
            await _httpClient.PostAsJsonAsync($"api/users/block/{userId}", null); // Cambia la URL según sea necesario
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _httpClient.DeleteAsync($"api/users/{userId}"); // Cambia la URL según sea necesario
        }
    }
}
