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
        public void CalculateScore_WithVariousPoints_ReturnsCorrectScore(int p1Points, int p2Points, string expectedScore)
        {
            var service = new TennisService();

            var actualScore = service.CalculateScore(p1Points, p2Points);

            Assert.Equal(expectedScore, actualScore);
        }
    }
}
