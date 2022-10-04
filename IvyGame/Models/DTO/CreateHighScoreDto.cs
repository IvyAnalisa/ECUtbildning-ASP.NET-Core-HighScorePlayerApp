using IvyGame.Models.Domain;

namespace IvyGame.Models.DTO
{
    public class CreateHighScoreDto
    {
        //public Game Game { get; set; }
        //  public HighScore HighScore { get; set; }
        //public IEnumerable<HighScore> HighScoresDto { get; set; } = new List<HighScore>();
        public int Id { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
        public string Player { get; set; }
        public virtual Game? Game { get; set; }//Set ? back to app work
        public int GameId { get; set; }
        // public string GameName { get; internal set; }
        // public string GameName { get; set; }
    }
}
