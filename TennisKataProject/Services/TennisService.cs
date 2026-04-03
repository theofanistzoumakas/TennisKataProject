namespace TennisKataProject.Services
{
    public class TennisService
    {
        public string CalculateScore(int p1Points, int p2Points)
        {

            if(p1Points>=4 && p1Points-p2Points>=2) return "Player 1 Wins";

            if (p2Points >= 4 && p2Points - p1Points >= 2) return "Player 2 Wins";

            if(p1Points >= 3 && p2Points >= 3)
            {
                if (p1Points == p2Points) return "Deuce";
                if (p1Points - p2Points == 1) return "Advantage for Player 1";
                if (p2Points - p1Points == 1) return "Advantage for Player 2";
            }


            string p1Score = GetScore(p1Points);
            string p2Score = GetScore(p2Points);
            

            if (p1Points == p2Points) return $"{p1Score}-All";

            return $"{p1Score}-{p2Score}";

        }

        private string GetScore(int playerPoints)
        {
            return playerPoints switch
            {
                1 => "15",
                2 => "30",
                3 => "40",
                _ => "Love"
            };
            
        }
    }
}
