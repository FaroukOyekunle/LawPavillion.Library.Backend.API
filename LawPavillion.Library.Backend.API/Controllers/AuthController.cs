using Microsoft.AspNetCore.Mvc;

using LawPavillion.Library.Backend.API.Dtos;
using LawPavillion.Library.Backend.API.Helpers;
using LawPavillion.Library.Backend.API.Interfaces.Services;
using AspNetCoreHero.Results;

namespace LawPavillion.Library.Backend.API.Controllers
{
    [ApiController]
    [Route(ApiRoute.Auth)]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        // Inject the user service through constructor
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Registers a new user and returns a success message.
        /// </summary>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto dto)
        {
            var result = await _userService.RegisterAsync(dto);
            if (!result.IsSuccessful)
            {
                return BadRequest(new { message = ConstantMessages.InvalidData, data = result });
            }

            return Ok(result);
        }

        /// <summary>
        /// Authenticates a user and returns a JWT token if successful.
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
        {
            var token = await _userService.AuthenticateAsync(dto);
            if (!token.IsSuccessful)
            {
                return BadRequest(new { message = ConstantMessages.Failed, data = token });
            }

            return Ok(token);
        }
    }
}
