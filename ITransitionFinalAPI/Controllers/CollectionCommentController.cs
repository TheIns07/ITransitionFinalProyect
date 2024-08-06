using ITransitionFinalAPI.Interfaces;
using ITransitionFinalAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITransitionFinalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollectionCommentController : Controller
    {
        private readonly ICollectionCommentRepository _repository;

        public CollectionCommentController(ICollectionCommentRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCollectionComment(CollectionComments collectionComment)
        {
            var result = await _repository.CreateCollectionComment(collectionComment);
            if (result)
            {
                return Ok("Collection comment created successfully.");
            }
            else
            {
                return BadRequest("Failed to create collection comment.");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCollectionComment(CollectionComments collectionComment)
        {
            var result = await _repository.DeleteCollectionComment(collectionComment);
            if (result)
            {
                return Ok("Collection comment deleted successfully.");
            }
            else
            {
                return BadRequest("Failed to delete collection comment.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCollectionComments()
        {
            var comments = await _repository.GetCollectionComments();
            return Ok(comments);
        }

        [HttpGet("{idCollection}/{idComment}")]
        public async Task<IActionResult> GetCollectionCommentById(int idCollection, int idComment)
        {
            var comment = await _repository.GetCollectionCommentById(idCollection, idComment);
            if (comment != null)
            {
                return Ok(comment);
            }
            else
            {
                return NotFound("Collection comment not found.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCollectionComment(CollectionComments collectionComment)
        {
            var result = await _repository.UpdateCollectionComment(collectionComment);
            if (result)
            {
                return Ok("Collection comment updated successfully.");
            }
            else
            {
                return BadRequest("Failed to update collection comment.");
            }
        }
    }
}
