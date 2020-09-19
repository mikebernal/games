namespace games.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public string Rules { get; set; }
    }
}