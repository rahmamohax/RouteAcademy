using GymMangBLL.Services.Interfaces;
using GymMangBLL.ViewModels.AccountViewModels;
using GymMangDAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymManagment.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(IAccountService accountService, SignInManager<ApplicationUser> signInManager)
        {
            _accountService = accountService;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); }
            
            var user = _accountService.ValidateUser(model);
            if (user == null)
            {
                ModelState.AddModelError("InvalidLogin", "Invalid Email or Password");
                return View(model);
            }

            var result = _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false).Result;

            if (result.IsNotAllowed)
                ModelState.AddModelError("InvalidLogin", "Your Account in not Allowed");

            if (result.IsLockedOut)
                ModelState.AddModelError("InvalidLogin", "Account is Locked Out");

            if (result.Succeeded)
                return RedirectToAction(controllerName: "Home", actionName: "Index");

            return View(model);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync().GetAwaiter().GetResult();
            return RedirectToAction(nameof(Login));
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
