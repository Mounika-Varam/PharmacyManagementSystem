using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmacyManagementSystem.API.Models.Domain;
using PharmacyManagementSystem.API.Models.DTO;
using PharmacyManagementSystem.API.Repositories;
using System.Data;

namespace PharmacyManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _repository.GetAllUsersAsync();
            var usersDto = _mapper.Map<List<UserDto>>(users);

            return Ok(usersDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var user = await _repository.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            var userDto = _mapper.Map<UserDto>(user);

            return Ok(userDto);
        }

        [HttpGet]
        [Route("{email:}/by-email")]
        //[Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetByEmailAsync([FromRoute] string email)
        {
            var userId = await _repository.GetUserByEmailAsync(email);

            if (userId == null)
            {
                return NotFound();
            }

            return Ok(userId);
        }


        [HttpPost]

        public async Task<IActionResult> CreateAsync([FromBody] AddUserRequestDto addUserRequestDto)
        {
            var user = _mapper.Map<User>(addUserRequestDto);

            user = await _repository.CreateUserAsync(user);

            var userDto = _mapper.Map<UserDto>(user);

            return Ok(userDto);
        }

    }
}
