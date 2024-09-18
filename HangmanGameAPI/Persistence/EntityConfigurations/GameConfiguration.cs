using HangmanGameAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HangmanGameAPI.Persistence.EntityConfigurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(game => game.Id);

            builder.HasOne(game => game.Player)
                   .WithMany(user => user.Games)
                   .HasForeignKey(game => game.PlayerId);

            builder.HasOne(game => game.Word)
                   .WithMany(word => word.Games)
                   .HasForeignKey(game => game.WordId);

            builder.HasOne(game => game.Challenge)
                   .WithOne(challenge => challenge.Game);

            builder.Property(game => game.IsWon).IsRequired();
        }
    }
}
