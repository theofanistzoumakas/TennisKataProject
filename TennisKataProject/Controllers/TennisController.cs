using Microsoft.AspNetCore.Mvc;
using TennisKataProject.Data;
using TennisKataProject.Models;
using TennisKataProject.Services;

namespace TennisKataProject.Controllers
{
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

            return Ok(game);
        }
    }
}
