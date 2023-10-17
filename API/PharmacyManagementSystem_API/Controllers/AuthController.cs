using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using PharmacyManagementSystem.API.Models.Domain;
using PharmacyManagementSystem.API.Models.DTO;
using PharmacyManagementSystem.API.Models.Identity;
using PharmacyManagementSystem.API.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace PharmacyManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepository _tokenRepository;
        private readonly IUserRepository _repository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository, IUserRepository repository)
        {
            this._userManager = userManager;
            this._tokenRepository = tokenRepository;
            this._repository = repository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            if (ModelState.IsValid) 
            {
                var user = new User()
                {
                    Email = registerRequestDto.Username,
                    FullName = registerRequestDto.FullName,
                    Gender = registerRequestDto.Gender,
                    PhoneNumber = registerRequestDto.PhoneNumber,
                    Role = registerRequestDto.Role,
                };

                user = await _repository.CreateUserAsync(user);

                var identityUser = new IdentityUser()
                {
                    UserName = registerRequestDto.Username,
                    Email = registerRequestDto.Username
                };
                var identityResult = await _userManager.CreateAsync(identityUser, registerRequestDto.Password);

                if (identityResult.Succeeded)
                {
                    if (registerRequestDto.Role != null && registerRequestDto.Role.Any())
                    {
                        identityResult = await _userManager.AddToRoleAsync(identityUser, registerRequestDto.Role);

                        if (identityResult.Succeeded)
                        {
                            return Ok("User was registered! Please login.");
                        }
                    }
                }
            }
            

            return BadRequest("Something went wrong");
        }



        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDto.Username);

            var userid = await _repository.GetUserByEmailAsync(loginRequestDto.Username);

            if (user != null)
            {
                var checkPasswordResult = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPasswordResult)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles != null)
                    {
                       var jwtToken = _tokenRepository.CreateJWTToken(user, roles.ToList());

                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken,
                            UserId = userid.ToString().ToUpper(),
                            Role = roles[0],
                        };
                       return Ok(response);

                    }
                }
            }
            return BadRequest("Username or Password incorect");
        }
    }
}
