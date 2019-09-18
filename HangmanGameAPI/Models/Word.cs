using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HangmanGameAPI.Models
{
    public class Word
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [DataType(DataType.Text)]
        public string Text { get; set; }

        public virtual List<Game> Games { get; set; }
    }
}
