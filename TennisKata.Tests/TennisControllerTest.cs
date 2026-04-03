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

        [Fact]
        public async Task ShowScore_ShouldRetuenNotFound_WhenGameDoesNotExist()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "PostTestDb")
                .Options;

            using var context = new AppDbContext(options);

            var controller = new TennisController(context, new TennisService());

            // Act
            var result = await controller.ShowScore(1000);

            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);

            //Assert
            Assert.Equal("Game not found.", notFoundResult.Value);
        }

        [Fact]
        public async Task PlayerScores_ShouldRetuenNotFound_WhenGameDoesNotExist()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "PostTestDb")
                .Options;

            using var context = new AppDbContext(options);

            var controller = new TennisController(context, new TennisService());

            // Act
            var result = await controller.PlayerScores(1000, "Player1");

            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);

            // Assert
            Assert.Equal("Game not found.", notFoundResult.Value);
        }
    }
}