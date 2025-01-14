using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevoloperJokesApp.Models;
using DevoloperJokesApp.ViewModels;;
using Microsoft.Extensions.Logging;

namespace DevoloperJokesApp.Controllers
{
    [AllowAnonymous]
    public class AccountController(UserManager<User> userManager, SignInManager<User> signInManager) : Controller
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly SignInManager<User> _signInManager = signInManager;

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var error = string.Empty;
            var user = await _userManager.FindByEmailAsync(model.Email!);
            if (user == null)
            {
                error = "There was an error while executing your request.";
                ViewData["Error"] = error;
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user!, model.Password!, isPersistent: model.RememberMe, lockoutOnFailure: true);
            if(!result.Succeeded)
            {
                error = "Invalid email or password";
                ViewData["Error"] = error;
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new User
            {
                UserName = model.Email,
                Email = model.Email,
                EmailConfirmed = false
            };

            var result = await _userManager.CreateAsync(user, model.Password!);

            if(!result.Succeeded)
            {
                return View(model);
            }

            ViewData["Email"] = model.Email;
            return View(nameof(AccountConfirmation));
        }

        [HttpGet]
        public async Task<IActionResult> AccountConfirmation(string email)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(x  => x.Email == email);
            if(user == null)
            {
                return NotFound();
            }

            user.EmailConfirmed = true;
            await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(Login));
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}