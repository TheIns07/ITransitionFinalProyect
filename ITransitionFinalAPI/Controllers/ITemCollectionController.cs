using Microsoft.AspNetCore.Mvc;
using ITransitionFinalAPI.Interfaces;
using ITransitionFinalAPI.Models;

namespace ITransitionFinalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ITemCollectionController : ControllerBase
    {
        private readonly IITemCollection _itemCollectionRepository;

        public ITemCollectionController(IITemCollection itemCollectionRepository)
        {
            _itemCollectionRepository = itemCollectionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCollections()
        {
            var collections = await _itemCollectionRepository.GetCollection();
            return Ok(collections);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetCollectionByName(string name)
        {
            var collection = await _itemCollectionRepository.GetCollectionByName(name);
            if (collection == null)
            {
                return NotFound();
            }
            return Ok(collection);
        }

        [HttpGet("byCollectionName/{collectionName}")]
        public async Task<IActionResult> GetCollectionByCollectionName(string collectionName)
        {
            var collections = await _itemCollectionRepository.GetCollectionByCollectionName(collectionName);
            return Ok(collections);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCollection([FromBody] ItemCollection itemCollection)
        {
            if (itemCollection == null)
            {
                return BadRequest("Invalid collection data.");
            }

            var created = await _itemCollectionRepository.CreateCollection(itemCollection);
            if (!created)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return Ok(itemCollection);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCollection(int id, [FromBody] ItemCollection itemCollection)
        {
            if (itemCollection == null || itemCollection.Id != id)
            {
                return BadRequest("Collection data is invalid.");
            }

            var updated = await _itemCollectionRepository.UpdateCollection(itemCollection);
            if (!updated)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollection(int id)
        {
            var itemCollection = await _itemCollectionRepository.GetCollectionByName(id.ToString());

            if (itemCollection == null)
            {
                return NotFound();
            }

            var deleted = await _itemCollectionRepository.DeleteCollection(itemCollection);
            if (!deleted)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }
    }
}
