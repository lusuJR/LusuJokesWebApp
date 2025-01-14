using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevoloperJokesApp.Models
{
    public class Joke
    {
        public int Id { get; set; }

        public string JokeQuestion { get; set; }=string.Empty;

        public string JokeAnswer { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }

        public string CreatedById { get; set; } = string.Empty ;

        public DateTime CreatedDateTime { get; set; } = DateTime.Now ;

        public string EditedById {  get; set; } = string.Empty ;

        public DateTime? EditedDateTime { get; set; }
        
        public User? User { get; set; }
    }
}