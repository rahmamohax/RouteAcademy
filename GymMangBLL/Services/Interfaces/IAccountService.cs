using GymMangBLL.ViewModels.AccountViewModels;
using GymMangDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangBLL.Services.Interfaces
{
    public interface IAccountService
    {
        public ApplicationUser? ValidateUser(LoginViewModel loginViewModel);
    }
}
