using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DevoloperJokesApp.Models
{
    public class User: IdentityUser
    {
        public ICollection<Joke> Jokes { get; set; } = new Collection<Joke>();
    }
}