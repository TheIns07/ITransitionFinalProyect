using ITransitionFinalAPI.Models;

namespace ITransitionFinalAPI.Interfaces
{
    public interface ICollectionCommentRepository
    {
        Task<bool> CreateCollectionComment(CollectionComments collectionComment);
        Task<bool> DeleteCollectionComment(CollectionComments collectionComment);
        Task<List<CollectionComments>> GetCollectionComments();
        Task<CollectionComments> GetCollectionCommentById(int idCollection, int idComment);
        Task<bool> UpdateCollectionComment(CollectionComments collectionComment);
        Task<bool> Save();
    }
}
