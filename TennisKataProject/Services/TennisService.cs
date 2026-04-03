namespace TennisKataProject.Services
{
    public class TennisService
    {
        public string CalculateScore(int p1Points, int p2Points)
        {

            if (p1Points == 0 && p2Points == 0) return "Love-All";
            if (p1Points == 1 && p2Points == 0) return "15-Love";
            if (p1Points == 0 && p2Points == 2) return "Love-30";

            return $"{p1Points}-{p2Points}";
        }
    }
}
