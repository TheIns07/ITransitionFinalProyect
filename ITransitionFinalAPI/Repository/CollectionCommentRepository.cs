using ITransitionFinalAPI.Data;
using ITransitionFinalAPI.Interfaces;
using ITransitionFinalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ITransitionFinalAPI.Repository
{
    public class CollectionCommentRepository : ICollectionCommentRepository
    {
        private readonly DataContext _data;

        public CollectionCommentRepository(DataContext data)
        {
            _data = data;
        }

        public async Task<bool> CreateCollectionComment(CollectionComments collectionComment)
        {
            await _data.CommentsInCollections.AddAsync(collectionComment);
            return await Save();
        }

        public async Task<bool> DeleteCollectionComment(CollectionComments collectionComment)
        {
            _data.CommentsInCollections.Remove(collectionComment);
            return await Save();
        }

        public async Task<List<CollectionComments>> GetCollectionComments()
        {
            return await _data.CommentsInCollections
                              .Include(cc => cc.Collection)
                              .Include(cc => cc.UserCollector)
                              .Include(cc => cc.Comment)
                              .ToListAsync();
        }

        public async Task<CollectionComments> GetCollectionCommentById(int idCollection, int idComment)
        {
            return await _data.CommentsInCollections
                              .Include(cc => cc.Collection)
                              .Include(cc => cc.UserCollector)
                              .Include(cc => cc.Comment)
                              .FirstOrDefaultAsync(cc => cc.IdCollection == idCollection && cc.IdComment == idComment);
        }

        public async Task<bool> UpdateCollectionComment(CollectionComments collectionComment)
        {
            _data.CommentsInCollections.Update(collectionComment);
            return await Save();
        }

        public async Task<bool> Save()
        {
            var saved = await _data.SaveChangesAsync();
            return saved > 0;
        }
    }
}
