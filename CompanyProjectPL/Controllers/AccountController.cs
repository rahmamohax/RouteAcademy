using CompanyProjectDAL.Models;
using CompanyProjectPL.Utilities;
using CompanyProjectPL.ViewModels.IdentityViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProjectPL.Controllers
{
    public class AccountController(UserManager<ApplicationUser> _userManager,
                                    SignInManager<ApplicationUser> _signInManager) : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = new ApplicationUser()
            {
                FirstName= model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email,
            };

            var res = _userManager.CreateAsync(user, model.Password).Result;
            if (res.Succeeded) return RedirectToAction(nameof(Login));
            else
                foreach (var error in res.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            return View(model);
            
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = _userManager.FindByEmailAsync(model.Email).Result;

            if (user is not null)
            {
                var isCorrect = _userManager.CheckPasswordAsync(user, model.Password).Result;
                if (isCorrect)
                {
                    var res =_signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false).Result;
                    if (res.IsNotAllowed) ModelState.AddModelError(string.Empty, "Your Account is Not Allowed");
                    if (res.IsLockedOut) ModelState.AddModelError(string.Empty, "Your Account is Locked");
                    if (res.Succeeded) 
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                }
            }
            else
                ModelState.AddModelError(string.Empty, "Invalid Login, Please Check Email and Password");
            return View();
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendResetPasswordLink(ForgetPasswordViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = _userManager.FindByEmailAsync(model.Email).Result;
                if (user != null)
                {
                    //Create reset Link
                    //Url/Account/ResetPasswordLink?email=rhma@gmail.com&token
                    var token = _userManager.GeneratePasswordResetTokenAsync(user).Result;
                    var resetLink = Url.Action("ResetPasswordLink", "Account", new { model.Email, token }, Request.Scheme);


                    //Create Email
                    var email = new Email()
                    {
                        To = model.Email,
                        Subject = "Reset Password",
                        Body = resetLink
                    };

                    //Send Email
                    var res =EmailSettings.SendEmail(email);
                    if (res) return RedirectToAction("CheckYouInbox");
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid");
            return View(nameof(ForgetPassword) , model); 
        }

        public IActionResult CheckYouInbox()
        {
            return View();
        }

        public IActionResult ResetPasswordLink(string email, string token)
        {
            TempData["email"] = email;
            TempData["token"] = token;
            return View();
        }

        [HttpPost]
        public IActionResult ResetPasswordLink(ResetPasswordViewModel model)
        {
            if(!ModelState.IsValid) { return View(model); }
            var email = TempData["email"] as string;
            var token = TempData["token"] as string;

            var user = _userManager.FindByEmailAsync(email).Result;
            if (user != null)
            {
                var res = _userManager.ResetPasswordAsync(user, token, model.Password).Result;
                if (res.Succeeded) return RedirectToAction(nameof(Login));

                else
                {
                    foreach (var error in res.Errors)
                        ModelState.AddModelError (string.Empty, error.Description);
                }
            }
            return View(model);
        }
    }
}
