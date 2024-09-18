using HangmanGameAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HangmanGameAPI.Persistence.EntityConfigurations
{
    public class ChallengeConfiguration : IEntityTypeConfiguration<Challenge>
    {
        public void Configure(EntityTypeBuilder<Challenge> builder)
        {
            builder.HasKey(challenge => challenge.Id);

            builder.HasOne(challenge => challenge.Game)
                   .WithOne(game => game.Challenge);

            builder.HasOne(challenge => challenge.Receiver)
                   .WithMany(user => user.ReceivedChallenges)
                   .HasForeignKey(challenge => challenge.ReceiverId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(challenge => challenge.Sender)
                   .WithMany(user => user.SentChallenges)
                   .HasForeignKey(challenge => challenge.SenderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(challenge => challenge.IsPlayed).IsRequired();
        }
    }
}
