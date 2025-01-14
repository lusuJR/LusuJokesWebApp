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

        
    }
}