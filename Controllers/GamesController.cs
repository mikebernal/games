using System.Threading.Tasks;
using games.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using games.Models;
using System;

namespace games.Controllers
{
  // http://localhost:5000/api/games
  [Route("api/[controller]")]
  [ApiController]
  public class GamesController : ControllerBase
  {
    private readonly GameDbConnection _context;
    public ILogger<GamesController> Logger { get; }

    public GamesController(
      GameDbConnection context,
      ILogger<GamesController> logger
    )
    {
      _context = context;
      Logger = logger;

    }
    // GET api/games
    [HttpGet]
    public async Task<IActionResult> GetGames()
    {
        var games = await _context.Games.ToListAsync();
        return Ok(games);
    }

    // GET api/games/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetGame(int id)
    {
        var game = await _context.Games.FirstOrDefaultAsync(x => x.Id == id);
        return Ok(game);
    }

    // POST api/games
    // [HttpPost]
    // public void Post([FromBody] string value)
    // {
      
    // }

    // POST: api/games
    [HttpPost]
    public async Task<IActionResult> PostGame(Game game)
    {
        _context.Games.Add(game);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetGames", new { id = game.Id }, game);
    }

    // PUT api/games/5
    // [HttpPut("{id}")]
    // public void Put(int id, [FromBody] string value)
    // {
    // }
    
    // PUT: api/TodoItems/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutGame(int id, Game game)
    {
        if (id != game.Id)
        {
            return BadRequest();
        }

        _context.Entry(game).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await GameExistsAsync(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/games/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        Logger.LogInformation("Hello from Games Controllers' Delete Method");            

        var game = await _context.Games.FindAsync(id);
        
        if (game == null)
        {
            return NotFound();
        }

        _context.Games.Remove(game);
        await _context.SaveChangesAsync();

        return Ok(game);

    }

    private async Task<bool> GameExistsAsync(int id) =>
      await _context.Games.AnyAsync(e => e.Id == id);

  }
}
