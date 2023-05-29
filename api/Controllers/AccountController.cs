using api.Models;
using api.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace api.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly AuthService _authService;

        public AccountController(
            UserManager<User> userManager,
            ILogger<AccountController> logger,
            AuthService authService
        )
        {
            _userManager = userManager;
            _logger = logger;
            _authService = authService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAppUser(UserRegisterDto userRegisterDto)
        {
            var user = new User
            {
                UserName = userRegisterDto.Username,
                Email = userRegisterDto.Email
            };
            var result = await _userManager.CreateAsync(user, userRegisterDto.Password);

            if (!result.Succeeded)
            {
                foreach (var err in result.Errors)
                {
                    _logger.LogError(err.Description);
                }
                return BadRequest("User Registration Attempt Failed");
            }
            return Ok("User Registered Successfully");
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAppUser(UserLoginDto userLoginDto)
        {
            var user = await _userManager.FindByEmailAsync(userLoginDto.Email);

            if (user is null)
                return BadRequest("User does not exist");

            var result = await _userManager.CheckPasswordAsync(user, userLoginDto.Password);

            if (!result)
                return BadRequest("Wrong Credentials");

            var userClaims = await _userManager.GetClaimsAsync(user);

            var token = _authService.GenerateToken(user, claims =>
            {
                claims.AddRange(userClaims);
            });

            return Ok(new { Token = token });
        }
    }
}
