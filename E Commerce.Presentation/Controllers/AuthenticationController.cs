
using E_Commerce.Service_Abstraction;
using E_Commerce.Shared.IdentityDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Commerce.Presentation.Controllers
{
    public class AuthenticationController : ApiBaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this._authenticationService = authenticationService;
        }
        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto login)
        {
            var result = await _authenticationService.LoginAsync(login);
            return HandleResult(result);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto register)
        {
            var result = await _authenticationService.RegisterAsync(register);
            return HandleResult(result);
        }

        [HttpGet("emailExists")]
        public async Task<ActionResult<bool>> CheckEmail(string email)
        {
            var res = await _authenticationService.CheckEmailAsync(email);
            return Ok(res);
        }

        [Authorize]
        [HttpGet("CurrentUser")]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email)!;
            var user = await _authenticationService.GetUserByEmailAsync(email);
            return HandleResult(user);
        }

    }
}
