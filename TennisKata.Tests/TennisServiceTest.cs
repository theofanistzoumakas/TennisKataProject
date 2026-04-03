using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisKataProject.Services;

namespace TennisKata.Tests
{
    public class TennisServiceTest
    {

        [Theory]
        [InlineData(0, 0, "Love-All")]
        [InlineData(1, 0, "15-Love")]
        [InlineData(0, 2, "Love-30")]
        [InlineData(3, 0, "40-Love")]
        [InlineData(1, 1, "15-All")]
        [InlineData(2, 2, "30-All")]
        [InlineData(3, 3, "Deuce")]
        [InlineData(4, 4, "Deuce")]
        [InlineData(4, 3, "Advantage for Player 1")]
        [InlineData(3, 4, "Advantage for Player 2")]
        public void CalculateScore_WithVariousPoints_ReturnsCorrectScore(int p1Points, int p2Points, string expectedScore)
        {
            var service = new TennisService();

            var actualScore = service.CalculateScore(p1Points, p2Points);

            Assert.Equal(expectedScore, actualScore);
        }
    }
}
