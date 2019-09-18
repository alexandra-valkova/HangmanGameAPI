using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HangmanGameAPI.Models
{
    public class Challenge
    {
        [Key]
        [ForeignKey("Game")]
        public int GameId { get; set; }

        [ForeignKey("Sender")]
        public int SenderId { get; set; }

        [ForeignKey("Receiver")]
        public int ReceiverId { get; set; }

        [Required]
        public bool Played { get; set; }

        [Required]
        public virtual User Sender { get; set; }

        [Required]
        public virtual User Receiver { get; set; }

        [Required]
        public virtual Game Game { get; set; }
    }
}
