using E_Commerce.Domain.Entities.IdentityModule;
using E_Commerce.Service_Abstraction;
using E_Commerce.Shared.CommonResult;
using E_Commerce.Shared.IdentityDtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;

namespace E_Commerce.Services
{
    public class AuthenticationService : Service_Abstraction.IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            this._userManager = userManager;
            this._configuration = configuration;
        }

        public async Task<bool> CheckEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user != null;
        }

        public async Task<Result<UserDto>> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user != null) Error.NotFound("User.NotFound", $"No User Found with email: {email}");

            return new UserDto(email, user.DisplayName, await GenerateTokenAsync(user));
        }

        public async Task<Result<UserDto>> LoginAsync(LoginDto login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null)
                return Error.InvalidCredintials("User.InvalidCredintials");

            var isPassValid =await _userManager.CheckPasswordAsync(user, login.Password);
            if (!isPassValid) return Error.InvalidCredintials("User.InvalidCredintials");

            var token =await GenerateTokenAsync(user);
            return new UserDto(user.Email!, user.DisplayName, token);
        }

        public async Task<Result<UserDto>> RegisterAsync(RegisterDto register)
        {
            var user = new ApplicationUser()
            {
                Email = register.Email,
                DisplayName = register.DisplayName,
                PhoneNumber = register.PhoneNumber,
                UserName = register.UserName,
            };
            var result = await _userManager.CreateAsync(user, register.Password);


            if (result.Succeeded) 
            { 
                var token = await GenerateTokenAsync(user);
                return new UserDto(user.Email, user.DisplayName, token);
            }

            return result.Errors.Select(e => Error.Validation(e.Code, e.Description)).ToList();
        }



        private async Task<string> GenerateTokenAsync(ApplicationUser user)
        {
            var claims = new List<Claim>() 
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Name, user.UserName!)
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            
                claims.Add(new Claim(ClaimTypes.Role, role));

            var mySecretKey = _configuration["JwtOptions:SecretKey"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(mySecretKey!));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtOptions:Issuer"],
                audience: _configuration["JwtOptions:Audience"],
                expires: DateTime.UtcNow.AddHours(1),
                claims: claims,
                signingCredentials: cred
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
