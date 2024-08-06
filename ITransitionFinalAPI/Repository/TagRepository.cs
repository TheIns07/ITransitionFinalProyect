using ITransitionFinalAPI.Data;
using ITransitionFinalAPI.Interfaces;
using ITransitionFinalAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ITransitionFinalAPI.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly DataContext _data;

        public TagRepository(DataContext data) 
        {
            _data = data;
        
        }
        public async Task<bool> CreateTag(Tag tag)
        {
            await _data.Tags.AddAsync(tag);
            return await Save();
        }

        public async Task<bool> DeleteTag(Tag tag)
        {
            _data.Tags.Remove(tag);
            return await Save();
        }

        public async Task<List<Tag>> GetTags()
        {
            return await _data.Tags.ToListAsync();
        }

        public async Task<Tag> GetTagsByName(string name)
        {
            return await _data.Tags.FirstOrDefaultAsync(t => t.Name == name);
        }

        public async Task<bool> UpdateTag(Tag tag)
        {
            _data.Tags.Update(tag);
            return await Save();
        }

        public async Task<bool> Save()
        {
            var saved = await _data.SaveChangesAsync();
            return saved > 0;
        }

        public async Task<List<Tag>> GetTagsByCollectionName(string collectionName)
        {
            var tags = await _data.Collections
                                    .Where(c => c.Name == collectionName)
                                    .SelectMany(c => c.Tags)
                                    .ToListAsync();
            return tags;
        }
    }
}
