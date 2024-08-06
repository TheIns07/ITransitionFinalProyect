using ITransitionFinalAPI.Interfaces;
using ITransitionFinalAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ITransitionFinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {

        private readonly ITagRepository _tagRepository;

        public TagController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(Tag tag)
        {
            var result = await _tagRepository.CreateTag(tag);
            if (result)
            {
                return Ok("Tag created successfully.");
            }
            else
            {
                return BadRequest("Failed to create tag.");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTag(Tag tag)
        {
            var result = await _tagRepository.DeleteTag(tag);
            if (result)
            {
                return Ok("Tag deleted successfully.");
            }
            else
            {
                return BadRequest("Failed to delete tag.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTags()
        {
            var tags = await _tagRepository.GetTags();
            return Ok(tags);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetTagByName(string name)
        {
            var tag = await _tagRepository.GetTagsByName(name);
            if (tag != null)
            {
                return Ok(tag);
            }
            else
            {
                return NotFound("Tag not found.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTag(Tag tag)
        {
            var result = await _tagRepository.UpdateTag(tag);
            if (result)
            {
                return Ok("Tag updated successfully.");
            }
            else
            {
                return BadRequest("Failed to update tag.");
            }
        }

        [HttpGet("by-collection/{collectionName}")]
        public async Task<IActionResult> GetTagsByCollectionName(string collectionName)
        {
            var tags = await _tagRepository.GetTagsByCollectionName(collectionName);
            return Ok(tags);
        }
    }
}
