using ITransitionFinalAPI.Data;
using ITransitionFinalAPI.Interfaces;
using ITransitionFinalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ITransitionFinalAPI.Repository
{
    public class LikedCollectionRepository : ILikedCollectionRepository
    {
        private readonly DataContext _data;

        public LikedCollectionRepository(DataContext data)
        {
            _data = data;
        }

        public async Task<bool> CreateLikedCollection(LikedCollection likedCollection)
        {
            await _data.LikedCollections.AddAsync(likedCollection);
            return await Save();
        }

        public async Task<bool> DeleteLikedCollection(LikedCollection likedCollection)
        {
            _data.LikedCollections.Remove(likedCollection);
            return await Save();
        }

        public async Task<LikedCollection> GetLikedCollection(int collectionId, int userId)
        {
            return await _data.LikedCollections
                .Include(lc => lc.Collection)
                .Include(lc => lc.UserCollector)
                .FirstOrDefaultAsync(lc => lc.IdCollection == collectionId && lc.IdUserCollector == userId);
        }

        public async Task<List<LikedCollection>> GetLikedCollections()
        {
            return await _data.LikedCollections
                .Include(lc => lc.Collection)
                .Include(lc => lc.UserCollector)
                .ToListAsync();
        }

        public async Task<List<LikedCollection>> GetLikedCollectionsByUser(int userId)
        {
            return await _data.LikedCollections
                .Where(lc => lc.IdUserCollector == userId)
                .Include(lc => lc.Collection)
                .Include(lc => lc.UserCollector)
                .ToListAsync();
        }

        public async Task<List<LikedCollection>> GetLikedCollectionsByCollection(int collectionId)
        {
            return await _data.LikedCollections
                .Where(lc => lc.IdCollection == collectionId)
                .Include(lc => lc.Collection)
                .Include(lc => lc.UserCollector)
                .ToListAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await _data.SaveChangesAsync();
            return saved > 0;
        }
    }
}
