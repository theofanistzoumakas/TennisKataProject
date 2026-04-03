namespace TennisKataProject.Services
{
    public class TennisService
    {
        public string CalculateScore(int p1Points, int p2Points)
        {

            if (p1Points == 0 && p2Points == 0) return "Love-All";
            if (p1Points == 1 && p2Points == 0) return "15-Love";
            if (p1Points == 0 && p2Points == 2) return "Love-30";
            if (p1Points == 3 && p2Points == 0) return "40-Love";
            if (p1Points == 1 && p2Points == 1) return "15-All";
            if (p1Points == 2 && p2Points == 2) return "30-All";
            if ((p1Points == 3 && p2Points == 3) || p1Points == 4 && p2Points == 4) return "Deuce";
            if (p1Points == 4 && p2Points == 3) return "Advantage for Player 1";
            if (p1Points == 3 && p2Points == 4) return "Advantage for Player 2";

            return $"{p1Points}-{p2Points}";
        }
    }
}
