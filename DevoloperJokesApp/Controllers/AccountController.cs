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
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}