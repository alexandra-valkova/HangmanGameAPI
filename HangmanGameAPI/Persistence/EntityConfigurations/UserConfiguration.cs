using HangmanGameAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HangmanGameAPI.Persistence.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Username).HasMaxLength(256).IsRequired();
            builder.Property(user => user.Email).HasMaxLength(256).IsRequired();
            builder.Property(user => user.Password).HasMaxLength(256).IsRequired();

            User player1 = new()
            {
                Id = 1,
                Username = "alexandra",
                Email = "alexandra@email.com",
                Password = "alexandra"
            };

            User player2 = new()
            {
                Id = 2,
                Username = "yanka",
                Email = "yanka@email.com",
                Password = "yanka"
            };

            builder.HasData(player1, player2);
        }
    }
}
