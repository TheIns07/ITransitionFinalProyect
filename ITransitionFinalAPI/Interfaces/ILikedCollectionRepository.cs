using ITransitionFinalAPI.Models;

namespace ITransitionFinalAPI.Interfaces
{
    public interface ILikedCollectionRepository
    {
        Task<bool> CreateLikedCollection(LikedCollection likedCollection);
        Task<bool> DeleteLikedCollection(LikedCollection likedCollection);
        Task<LikedCollection> GetLikedCollection(int collectionId, int userId);
        Task<List<LikedCollection>> GetLikedCollections();
        Task<List<LikedCollection>> GetLikedCollectionsByUser(int userId);
        Task<List<LikedCollection>> GetLikedCollectionsByCollection(int collectionId);
        Task<bool> Save();
    }
}
