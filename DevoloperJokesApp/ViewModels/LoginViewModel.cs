using System.ComponentModel.DataAnnotations;
namespace DevoloperJokesApp.ViewModels
{
    public class LoginViewModel
    {
         [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }
    }
}