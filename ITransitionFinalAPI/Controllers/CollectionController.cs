using ITransitionFinalAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ITransitionFinalAPI.Models;

namespace ITransitionFinalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollectionController : Controller
    {
        private readonly ICollectionRepository _repository;

        public CollectionController(ICollectionRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCollection(Collection collection)
        {
            var result = await _repository.CreateCollection(collection);
            if (result)
            {
                return Ok("Collection created successfully.");
            }
            else
            {
                return BadRequest("Failed to create collection.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollection(int id)
        {
            var collection = await _repository.GetCollectionById(id);
            if (collection == null)
            {
                return NotFound("Collection not found.");
            }

            var result = await _repository.DeleteCollection(collection);
            if (result)
            {
                return Ok("Collection deleted successfully.");
            }
            else
            {
                return BadRequest("Failed to delete collection.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCollectionById(int id)
        {
            var collection = await _repository.GetCollectionById(id);
            if (collection != null)
            {
                return Ok(collection);
            }
            else
            {
                return NotFound("Collection not found.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCollections()
        {
            var collections = await _repository.GetCollections();
            return Ok(collections);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCollection(Collection collection)
        {
            var result = await _repository.UpdateCollection(collection);
            if (result)
            {
                return Ok("Collection updated successfully.");
            }
            else
            {
                return BadRequest("Failed to update collection.");
            }
        }

        [HttpGet("recent")]
        public async Task<IActionResult> GetFiveMostRecentCollections()
        {
            var collections = await _repository.GetFiveMostRecentCollections();
            return Ok(collections);
        }

        [HttpGet("top-users")]
        public async Task<IActionResult> GetTopUsersByCollections()
        {
            var users = await _repository.GetTopUsersByCollections();
            return Ok(users);
        }
    }
}
