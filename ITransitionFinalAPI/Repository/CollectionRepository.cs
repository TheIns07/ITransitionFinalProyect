using ITransitionFinalAPI.Data;
using ITransitionFinalAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using ITransitionFinalAPI.Models;

namespace ITransitionFinalAPI.Repository
{
    public class CollectionRepository : ICollectionRepository
    {

        private readonly DataContext _data;

        public CollectionRepository(DataContext data)
        {
            _data = data;
        }

        public async Task<bool> CreateCollection(Collection collection)
        {
            await _data.Collections.AddAsync(collection);
            return await Save();
        }

        public async Task<bool> DeleteCollection(Collection collection)
        {
            _data.Collections.Remove(collection);
            return await Save();
        }

        public async Task<Collection> GetCollectionById(int id)
        {
            return await _data.Collections
                .Include(c => c.Tags)
                .Include(c => c.Comments).ThenInclude(cc => cc.Comment)
                .Include(c => c.LikedCollections)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Collection>> GetCollections()
        {
            return await _data.Collections
                .Include(c => c.Tags)
                .Include(c => c.Comments).ThenInclude(cc => cc.Comment)
                .Include(c => c.LikedCollections)
                .ToListAsync();
        }

        public async Task<bool> UpdateCollection(Collection collection)
        {
            _data.Collections.Update(collection);
            return await Save();
        }

        public async Task<bool> Save()
        {
            var saved = await _data.SaveChangesAsync();
            return saved > 0;
        }

        public async Task<List<Collection>> GetFiveMostRecentCollections()
        {
            return await _data.Collections
                .OrderByDescending(c => c.DateSigned)
                .Take(5)
                .ToListAsync();
        }

        public async Task<List<UserCollector>> GetTopUsersByCollections()
        {
            return await _data.UserCollectors
                .OrderByDescending(uc => uc.Collections.Count)
                .Take(5)
                .ToListAsync();
        }
    }
}
