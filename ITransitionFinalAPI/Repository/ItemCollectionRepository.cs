using ITransitionFinalAPI.Data;
using ITransitionFinalAPI.Interfaces;
using ITransitionFinalAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace ITransitionFinalAPI.Repository
{
    public class ItemCollectionRepository : IITemCollection 
    {
        private readonly DataContext _dataContext;

        public ItemCollectionRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<ItemCollection>> GetCollection()
        {
            return await _dataContext.ItemsCollections.ToListAsync();
        }

        public async Task<ItemCollection> GetCollectionByName(string name)
        {
            return await _dataContext.ItemsCollections.FirstOrDefaultAsync(ic => ic.Name == name);
        }

        public async Task<bool> CreateCollection(ItemCollection itemCollection)
        {
            await _dataContext.ItemsCollections.AddAsync(itemCollection);
            return await Save();
        }

        public async Task<bool> UpdateCollection(ItemCollection itemCollection)
        {
            _dataContext.ItemsCollections.Update(itemCollection);
            return await Save();
        }

        public async Task<bool> DeleteCollection(ItemCollection itemCollection)
        {
            _dataContext.ItemsCollections.Remove(itemCollection);
            return await Save();
        }

        public async Task<List<ItemCollection>> GetCollectionByCollectionName(string collectionName)
        {
            return await _dataContext.ItemsCollections
                .Where(ic => ic.Collection.Name == collectionName)
                .ToListAsync();
        }

        public async Task<bool> Save()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }

    }
}
