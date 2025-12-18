using EnterpriseApi.Domain.Entities;
using EnterpriseApi.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // =========================
        // GET: api/users
        // =========================
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        // =========================
        // GET: api/users/{id}
        // =========================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // =========================
        // POST: api/users
        // =========================
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            if (await _userRepository.EmailExistsAsync(user.Email))
            {
                return BadRequest("Email already exists");
            }

            user.Id = Guid.NewGuid();
            await _userRepository.AddAsync(user);

            return CreatedAtAction(
                nameof(GetById),
                new { id = user.Id },
                user
            );
        }
    }
}
