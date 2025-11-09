using GymMangBLL.Services.Interfaces;
using GymMangBLL.ViewModels.AccountViewModels;
using GymMangDAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangBLL.Services.Classes
{
    public class AccountService : IAccountService 
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public ApplicationUser? ValidateUser(LoginViewModel loginViewModel)
        {
            var user = _userManager.FindByEmailAsync(loginViewModel.Email).Result;
            if (user is null) return null;

            var isPassValid = _userManager.CheckPasswordAsync(user, loginViewModel.Password).Result;

            return isPassValid ? user : null;
        }
    }
}
