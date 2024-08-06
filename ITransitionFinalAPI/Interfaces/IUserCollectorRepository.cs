using ITransitionFinalAPI.Models;

namespace ITransitionFinalAPI.Interfaces
{
    public interface IUserCollectorRepository
    {
        Task<bool> CreateUserCollector(UserCollector userCollector);
        Task<bool> DeleteUserCollector(UserCollector userCollector);
        Task<UserCollector> GetUserCollector(int id);
        Task<List<UserCollector>> GetUserCollectors();
        Task<UserCollector> GetUserCollectorByName(string name);
        Task<bool> UpdateUserCollector(UserCollector userCollector);
        Task<bool> Save();
    }
}
