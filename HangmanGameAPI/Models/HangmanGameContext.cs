using Microsoft.EntityFrameworkCore;

namespace HangmanGameAPI.Models
{
    public class HangmanGameContext : DbContext
    {
        public HangmanGameContext(DbContextOptions<HangmanGameContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Word> Words { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Challenge> Challenges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Challenge>().HasOne(c => c.Receiver).WithMany(u => u.ReceivedChallenges).HasForeignKey(c => c.ReceiverId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Challenge>().HasOne(c => c.Sender).WithMany(u => u.SentChallenges).HasForeignKey(c => c.SenderId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
