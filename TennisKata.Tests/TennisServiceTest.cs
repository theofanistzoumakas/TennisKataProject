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
        public void CalculateScore_WithVariousPoints_ReturnsCorrectScore(int p1Points, int p2Points, string expectedScore)
        {
            var service = new TennisService();

            var actualScore = service.CalculateScore(p1Points, p2Points);

            Assert.Equal(expectedScore, actualScore);
        }
    }
}
