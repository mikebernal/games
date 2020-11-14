using games.Models;
using Microsoft.EntityFrameworkCore;

namespace games.Data
{
  public class GameDbConnection : DbContext
  {
    public  GameDbConnection(DbContextOptions<GameDbConnection> options) : base(options) {}

    public DbSet<Game> Games { get; set; }
    public DbSet<Competitor> Competitors { get; set; }
  }
}