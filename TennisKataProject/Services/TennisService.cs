namespace TennisKataProject.Services
{
    public class TennisService
    {
        public string CalculateScore(int p1Points, int p2Points)
        {

            if (p1Points == 0 && p2Points == 0) return "Love-All";

            return $"{p1Points}-{p2Points}";
        }
    }
}
