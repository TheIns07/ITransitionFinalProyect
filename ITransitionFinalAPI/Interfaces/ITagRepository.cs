using ITransitionFinalAPI.Models;

namespace ITransitionFinalAPI.Interfaces
{
    public interface ITagRepository
    {
        Task<List<Tag>> GetTags();
        Task<Tag> GetTagsByName(string name);
        Task<bool> CreateTag(Tag tag);
        Task<bool> UpdateTag(Tag tag);
        Task<bool> DeleteTag(Tag tag);
        Task<List<Tag>> GetTagsByCollectionName(string collectionName);
        Task<bool> Save();

    }
}
