using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;  

namespace DevoloperJokesApp.Models
{
    public class User: IdentityUser
    {
        public ICollection<Joke> Jokes { get; set; } = new Collection<Joke>();  // Now Collection<Joke> is recognized
    }
}
