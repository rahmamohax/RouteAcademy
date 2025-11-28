using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Shared.IdentityDtos
{
    public record RegisterDto([EmailAddress]string Email, string DisplayName, string UserName,[Phone] string PhoneNumber, string Password);
}
