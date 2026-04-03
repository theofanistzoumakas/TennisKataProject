using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using TennisKataProject.Data;
using TennisKataProject.Models;
using TennisKataProject.Services;

namespace TennisKataProject.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class TennisController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly TennisService _tennisService;

        public TennisController(AppDbContext context, TennisService tennisService)
        {
            _context = context;
            _tennisService = tennisService;
        }

        [HttpPost]
        public async Task<IActionResult> StartGame()
        {
            var newGame = new TennisGame();
            _context.TennisGames.Add(newGame);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ShowScore),new { id = newGame.Id }, newGame);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ShowScore(int id)
        {
            var game = await _context.TennisGames.FindAsync(id);

            return game == null ? NotFound("Game not found.") : Ok(game);
        }

        [HttpPost("{gameId}/{player}/score")] 
        public async Task<IActionResult> PlayerScores(int gameId, string player)
        {
            var game = await _context.TennisGames.FindAsync(gameId);

            if (game == null) return NotFound("Game not found.");
            if (game.isFinished) return BadRequest("The game is finished.");

            if (player.Equals("Player1")) game.Player1Points++;
            else if (player.Equals("Player2")) game.Player2Points++;
            else return BadRequest("Player not found.");

            game.CurrentScoreText = _tennisService.CalculateScore(game.Player1Points, game.Player2Points);

            if (game.CurrentScoreText.Equals("Player 1 Wins") || game.CurrentScoreText.Equals("Player 2 Wins")) game.isFinished = true;

            await _context.SaveChangesAsync();

            return Ok(game);
        }
    }
}
