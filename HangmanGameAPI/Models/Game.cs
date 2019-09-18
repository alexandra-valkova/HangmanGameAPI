using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HangmanGameAPI.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Player")]
        public int PlayerId { get; set; }

        [ForeignKey("Word")]
        public int WordId { get; set; }

        [Required]
        public bool Won { get; set; }

        [Required]
        public virtual User Player { get; set; }

        [Required]
        public virtual Word Word { get; set; }

        public virtual Challenge Challenge { get; set; }
    }
}
