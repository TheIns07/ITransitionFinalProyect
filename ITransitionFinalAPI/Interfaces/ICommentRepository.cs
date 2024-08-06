using ITransitionFinalAPI.Models;

namespace ITransitionFinalAPI.Interfaces
{
    public interface ICommentRepository
    {
        Task<bool> CreateComment(Comment comment);
        Task<bool> DeleteComment(Comment comment);
        Task<Comment> GetCommentById(int id);
        Task<List<Comment>> GetComments();
        Task<bool> UpdateComment(Comment comment);
        Task<bool> Save();
    }
}
