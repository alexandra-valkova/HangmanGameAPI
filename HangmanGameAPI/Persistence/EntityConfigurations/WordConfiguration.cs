using HangmanGameAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HangmanGameAPI.Persistence.EntityConfigurations
{
    public class WordConfiguration : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder.HasKey(word => word.Id);

            builder.HasMany(word => word.Games)
                   .WithOne(game => game.Word)
                   .HasForeignKey(game => game.WordId);

            builder.Property(word => word.Text).HasMaxLength(256).IsRequired();

            //using StreamReader reader = new("Words.txt");

            //string wordsString = reader.ReadToEnd();

            //IEnumerable<Word> words = wordsString.Split(',')
            //                                     .Select(word => new Word { Text = word.Trim() });

            //builder.HasData(words);
        }
    }
}
