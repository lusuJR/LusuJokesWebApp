using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DevoloperJokesApp.Data.EntityConfiguration;
using DevoloperJokesApp.Models;

namespace DevoloperJokesApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
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
}
