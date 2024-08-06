using ITransitionFinalAPI.Interfaces;
using ITransitionFinalAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITransitionFinalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        private readonly ICommentRepository _repository;

        public CommentController(ICommentRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(Comment comment)
        {
            var result = await _repository.CreateComment(comment);
            if (result)
            {
                return Ok("Comment created successfully.");
            }
            else
            {
                return BadRequest("Failed to create comment.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _repository.GetCommentById(id);
            if (comment == null)
            {
                return NotFound("Comment not found.");
            }

            var result = await _repository.DeleteComment(comment);
            if (result)
            {
                return Ok("Comment deleted successfully.");
            }
            else
            {
                return BadRequest("Failed to delete comment.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var comment = await _repository.GetCommentById(id);
            if (comment != null)
            {
                return Ok(comment);
            }
            else
            {
                return NotFound("Comment not found.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            var comments = await _repository.GetComments();
            return Ok(comments);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(Comment comment)
        {
            var result = await _repository.UpdateComment(comment);
            if (result)
            {
                return Ok("Comment updated successfully.");
            }
            else
            {
                return BadRequest("Failed to update comment.");
            }
        }
    }
}
