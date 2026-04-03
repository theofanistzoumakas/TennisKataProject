using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TennisKataProject.Controllers;
using TennisKataProject.Data;
using TennisKataProject.Services;

namespace TennisKata.Tests
{
    public class TennisControllerTest
    {
        [Fact]
        public async Task Post_ShouldCreateGame_AndReturnCreatedAtAction()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "PostTestDb")
                .Options;

            using var context = new AppDbContext(options);

            var controller = new TennisController(context, new TennisService());

            // Act
            var result = await controller.StartGame();

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(201, createdAtActionResult.StatusCode);

            Assert.Equal(1, await context.TennisGames.CountAsync());

        }
    }
}