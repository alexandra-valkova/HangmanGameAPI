using HangmanGameAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HangmanGameAPI.Data
{
    public class HangmanGameContext : DbContext
    {
        public HangmanGameContext(DbContextOptions<HangmanGameContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Word> Words { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Challenge> Challenges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Challenge>()
                        .HasOne(challenge => challenge.Receiver)
                        .WithMany(user => user.ReceivedChallenges)
                        .HasForeignKey(challenge => challenge.ReceiverId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Challenge>()
                        .HasOne(challenge => challenge.Sender)
                        .WithMany(user => user.SentChallenges)
                        .HasForeignKey(challenge => challenge.SenderId)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
