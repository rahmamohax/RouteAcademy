using E_Commerce.Shared.CommonResult;
using E_Commerce.Shared.IdentityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service_Abstraction
{
    public interface IAuthenticationService
    {
        //login
        //email, pass => token , displayName, email
        Task<Result<UserDto>> LoginAsync(LoginDto login);

        //register
        //email , pass , username, displayName, phoneNumber => token , displayName, email
        Task<Result<UserDto>> RegisterAsync(RegisterDto register);

        Task<bool> CheckEmailAsync(string email);

        Task<Result<UserDto>> GetUserByEmailAsync(string email);



    }
}
