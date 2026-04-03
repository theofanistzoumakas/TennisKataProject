using Microsoft.EntityFrameworkCore;
using TennisKataProject.Models;

namespace TennisKataProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<TennisGame> TennisGames { get; set; }
    }
}
