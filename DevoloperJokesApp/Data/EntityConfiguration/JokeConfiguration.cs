using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DevoloperJokesApp.Models;

namespace DevoloperJokesApp.Data.EntityConfiguration
{
    public class JokeConfiguration : IEntityTypeConfiguration<Joke>
    {
        public void Configure(EntityTypeBuilder<Joke> builder)
        {
            builder.ToTable("Jokes");

            builder.Property(x => x.JokeQuestion)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.JokeAnswer)
                .IsRequired()
                .HasMaxLength(500);
            
            builder.HasOne(x => x.User)
                .WithMany(x => x.Jokes)
                .HasForeignKey(x => x.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
