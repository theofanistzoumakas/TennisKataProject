using Microsoft.AspNetCore.Mvc;
using TennisKataProject.Data;
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
            throw new NotImplementedException();
        }
    }
}
