using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TennisKataProject.Controllers;
using TennisKataProject.Data;
using TennisKataProject.Models;
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
        public async Task PlayerScores_ShouldReturnNotFound_WhenGameDoesNotExist()
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

        [Fact]
        public async Task PlayerScores_ShouldReturnBadRequest_WhenPlayerNotExist()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "PostTestDb")
                .Options;

            using var context = new AppDbContext(options);

            var controller = new TennisController(context, new TennisService());

            var game = new TennisGame
            {
                Id = 1,
                Player1Points = 1,
                Player2Points = 1,
                isFinished = false,
                CurrentScoreText = "15-All"
            };

            context.Add(game);

            await context.SaveChangesAsync();

            // Act
            var result = await controller.PlayerScores(1, "Player3");

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);

            // Assert
            Assert.Equal("Player not found.", badRequestResult.Value);
        }
    }
}