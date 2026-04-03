namespace TennisKataProject.Models
{
    public class TennisGame
    {
        public int Id { get; set; }
        public int Player1Points { get; set; } = 0;
        public int Player2Points { get; set; } = 0;

        public string CurrentScoreText { get; set; } = "Love-All";

        public bool isFinished { get; set; } = false;


    }
}
