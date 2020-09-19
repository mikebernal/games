using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using games.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace games.Controllers
{
  // http://localhost:5000/api/games
  [Route("api/[controller]")]
  [ApiController]
  public class GamesController : ControllerBase
  {
    private readonly GameDbConnection _context;
    public GamesController(GameDbConnection context)
    {
      _context = context;
    }
    // GET api/games
    [HttpGet]
    public async Task<IActionResult> GetGames()
    {
        var games =  await _context.Games.ToListAsync();
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
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/games/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/games/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
