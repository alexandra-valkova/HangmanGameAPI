using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HangmanGameAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public virtual List<Game> Games { get; set; }

        public virtual List<Challenge> SentChallenges { get; set; }

        public virtual List<Challenge> ReceivedChallenges { get; set; }
    }
}
