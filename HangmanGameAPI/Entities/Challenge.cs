namespace HangmanGameAPI.Entities
{
    public class Challenge
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        public int SenderId { get; set; }

        public int ReceiverId { get; set; }

        public bool IsPlayed { get; set; }

        public virtual Game Game { get; set; }

        public virtual User Sender { get; set; }

        public virtual User Receiver { get; set; }
    }
}
