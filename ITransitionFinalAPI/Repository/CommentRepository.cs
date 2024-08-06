using ITransitionFinalAPI.Data;
using ITransitionFinalAPI.Interfaces;
using ITransitionFinalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ITransitionFinalAPI.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DataContext _data;

        public CommentRepository(DataContext data)
        {
            _data = data;
        }

        public async Task<bool> CreateComment(Comment comment)
        {
            await _data.Comments.AddAsync(comment);
            return await Save();
        }

        public async Task<bool> DeleteComment(Comment comment)
        {
            _data.Comments.Remove(comment);
            return await Save();
        }

        public async Task<Comment> GetCommentById(int id)
        {
            return await _data.Comments
                .Include(c => c.CollectionComments)
                .ThenInclude(cc => cc.Collection)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Comment>> GetComments()
        {
            return await _data.Comments
                .Include(c => c.CollectionComments)
                .ThenInclude(cc => cc.Collection)
                .ToListAsync();
        }

        public async Task<bool> UpdateComment(Comment comment)
        {
            _data.Comments.Update(comment);
            return await Save();
        }

        public async Task<bool> Save()
        {
            var saved = await _data.SaveChangesAsync();
            return saved > 0;
        }
    }
}
