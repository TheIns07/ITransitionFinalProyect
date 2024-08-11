using ITransitionFinalAPI.Models;
namespace ITransitionFinalAPI.Interfaces
{
    public interface IITemCollection
    {
        Task<List<ItemCollection>> GetCollection();
        Task<ItemCollection> GetCollectionByName(string name);
        Task<bool> CreateCollection(ItemCollection tag);
        Task<bool> UpdateCollection(ItemCollection tag);
        Task<bool> DeleteCollection(ItemCollection tag);
        Task<List<ItemCollection>> GetCollectionByCollectionName(string collectionName);
        Task<bool> Save();
    }
}
