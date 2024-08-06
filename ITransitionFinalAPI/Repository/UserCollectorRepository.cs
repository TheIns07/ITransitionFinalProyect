using ITransitionFinalAPI.Data;
using ITransitionFinalAPI.Interfaces;
using ITransitionFinalAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace ITransitionFinalAPI.Repository
{
    public class UserCollectorRepository : IUserCollectorRepository
    {
        private readonly DataContext _data;

        public UserCollectorRepository(DataContext data)
        {
            _data = data;
        }

        public async Task<bool> CreateUserCollector(UserCollector userCollector)
        {
            await _data.UserCollectors.AddAsync(userCollector);
            return await Save();
        }

        public async Task<bool> DeleteUserCollector(UserCollector userCollector)
        {
            _data.UserCollectors.Remove(userCollector);
            return await Save();
        }

        public async Task<UserCollector> GetUserCollector(int id)
        {
            return await _data.UserCollectors
                .Include(uc => uc.Collections)
                .Include(uc => uc.LikedCollections)
                .Include(uc => uc.Comments)
                .FirstOrDefaultAsync(uc => uc.Id == id);
        }

        public async Task<List<UserCollector>> GetUserCollectors()
        {
            return await _data.UserCollectors
                .Include(uc => uc.Collections)
                .Include(uc => uc.LikedCollections)
                .Include(uc => uc.Comments)
                .ToListAsync();
        }

        public async Task<UserCollector> GetUserCollectorByName(string name)
        {
            return await _data.UserCollectors
                .Include(uc => uc.Collections)
                .Include(uc => uc.LikedCollections)
                .Include(uc => uc.Comments)
                .FirstOrDefaultAsync(uc => uc.Name == name);
        }

        public async Task<bool> UpdateUserCollector(UserCollector userCollector)
        {
            _data.UserCollectors.Update(userCollector);
            return await Save();
        }

        public async Task<bool> Save()
        {
            var saved = await _data.SaveChangesAsync();
            return saved > 0;
        }
    }
}
