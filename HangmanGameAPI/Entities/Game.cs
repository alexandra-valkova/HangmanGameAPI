namespace HangmanGameAPI.Entities
{
    public class Game
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }

        public int WordId { get; set; }

        public bool IsWon { get; set; }

        public virtual User Player { get; set; }

        public virtual Word Word { get; set; }

        public virtual Challenge Challenge { get; set; }
    }
}
