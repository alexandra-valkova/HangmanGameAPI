using HangmanGameAPI.Entities;
using HangmanGameAPI.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace HangmanGameAPI.Persistence
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

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new WordConfiguration());
            modelBuilder.ApplyConfiguration(new GameConfiguration());
            modelBuilder.ApplyConfiguration(new ChallengeConfiguration());
        }
    }
}
