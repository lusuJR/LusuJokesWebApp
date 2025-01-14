using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgramJokesWebApp.Data.EntityConfiguration;
using ProgramJokesWebApp.Models;

namespace DevoloperJokesApp.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {  
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new JokeConfiguration());
        }

        public DbSet<Joke> Jokes { get; set; } = default!;
    }
    {
        
    }
}