using System.ComponentModel.DataAnnotations;
namespace DevoloperJokesApp.ViewModels
{
    public class JokeViewModel
    {
        public int Id { get; set; }
        public string? JokeQuestion { get; set; }
        public string? JokeAnswer { get; set; }
        public string? Developer { get; set; }
    }
}