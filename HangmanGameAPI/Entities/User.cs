namespace HangmanGameAPI.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public virtual ICollection<Challenge> SentChallenges { get; set; }

        public virtual ICollection<Challenge> ReceivedChallenges { get; set; }
    }
}
