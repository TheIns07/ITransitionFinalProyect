using ITransitionFinalAPI.Interfaces;
using ITransitionFinalAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITransitionFinalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikedCollectionController : Controller
    {
        private readonly ILikedCollectionRepository _repository;

        public LikedCollectionController(ILikedCollectionRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLikedCollection(LikedCollection likedCollection)
        {
            var result = await _repository.CreateLikedCollection(likedCollection);
            if (result)
            {
                return Ok("Liked collection created successfully.");
            }
            else
            {
                return BadRequest("Failed to create liked collection.");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLikedCollection(int collectionId, int userId)
        {
            var likedCollection = await _repository.GetLikedCollection(collectionId, userId);
            if (likedCollection == null)
            {
                return NotFound("Liked collection not found.");
            }

            var result = await _repository.DeleteLikedCollection(likedCollection);
            if (result)
            {
                return Ok("Liked collection deleted successfully.");
            }
            else
            {
                return BadRequest("Failed to delete liked collection.");
            }
        }

        [HttpGet("{collectionId}/{userId}")]
        public async Task<IActionResult> GetLikedCollection(int collectionId, int userId)
        {
            var likedCollection = await _repository.GetLikedCollection(collectionId, userId);
            if (likedCollection != null)
            {
                return Ok(likedCollection);
            }
            else
            {
                return NotFound("Liked collection not found.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetLikedCollections()
        {
            var likedCollections = await _repository.GetLikedCollections();
            return Ok(likedCollections);
        }

        [HttpGet("byUser/{userId}")]
        public async Task<IActionResult> GetLikedCollectionsByUser(int userId)
        {
            var likedCollections = await _repository.GetLikedCollectionsByUser(userId);
            return Ok(likedCollections);
        }

        [HttpGet("byCollection/{collectionId}")]
        public async Task<IActionResult> GetLikedCollectionsByCollection(int collectionId)
        {
            var likedCollections = await _repository.GetLikedCollectionsByCollection(collectionId);
            return Ok(likedCollections);
        }
    }
}
