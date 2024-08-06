using ITransitionFinalAPI.Interfaces;
using ITransitionFinalAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITransitionFinalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserCollectorController : Controller
    {
        private readonly IUserCollectorRepository _repository;

        public UserCollectorController(IUserCollectorRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserCollector(UserCollector userCollector)
        {
            var result = await _repository.CreateUserCollector(userCollector);
            if (result)
            {
                return Ok("User collector created successfully.");
            }
            else
            {
                return BadRequest("Failed to create user collector.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserCollector(int id)
        {
            var userCollector = await _repository.GetUserCollector(id);
            if (userCollector == null)
            {
                return NotFound("User collector not found.");
            }

            var result = await _repository.DeleteUserCollector(userCollector);
            if (result)
            {
                return Ok("User collector deleted successfully.");
            }
            else
            {
                return BadRequest("Failed to delete user collector.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserCollector(int id)
        {
            var userCollector = await _repository.GetUserCollector(id);
            if (userCollector != null)
            {
                return Ok(userCollector);
            }
            else
            {
                return NotFound("User collector not found.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUserCollectors()
        {
            var userCollectors = await _repository.GetUserCollectors();
            return Ok(userCollectors);
        }

        [HttpGet("byName/{name}")]
        public async Task<IActionResult> GetUserCollectorByName(string name)
        {
            var userCollector = await _repository.GetUserCollectorByName(name);
            if (userCollector != null)
            {
                return Ok(userCollector);
            }
            else
            {
                return NotFound("User collector not found.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserCollector(UserCollector userCollector)
        {
            var result = await _repository.UpdateUserCollector(userCollector);
            if (result)
            {
                return Ok("User collector updated successfully.");
            }
            else
            {
                return BadRequest("Failed to update user collector.");
            }
        }
    }
}
