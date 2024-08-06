using ITransitionFinalAPI.Models;
namespace ITransitionFinalAPI.Interfaces
{
    public interface ICollectionRepository
    {
        Task<bool> CreateCollection(Collection collection);
        Task<bool> DeleteCollection(Collection collection);
        Task<Collection> GetCollectionById(int id);
        Task<List<Collection>> GetCollections();
        Task<bool> UpdateCollection(Collection collection);
        Task<bool> Save();
        Task<List<Collection>> GetFiveMostRecentCollections();
        Task<List<UserCollector>> GetTopUsersByCollections();
    }
}
