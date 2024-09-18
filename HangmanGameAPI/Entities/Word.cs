namespace HangmanGameAPI.Entities
{
    public class Word
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
