using HangmanGameAPI.Entities;
using HangmanGameAPI.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HangmanGameAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly HangmanGameContext _context;

        public GamesController(HangmanGameContext context)
        {
            _context = context;
        }

        [HttpGet(Name = nameof(GetGames))]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        {
            return await _context.Games.ToListAsync();
        }

        [HttpGet("{id:int}", Name = nameof(GetGame))]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            Game? game = await _context.Games.FindAsync(id);

            if (game is null)
            {
                return NotFound();
            }

            return game;
        }

        [HttpPost(Name = nameof(CreateGame))]
        public async Task<ActionResult<Game>> CreateGame(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGame", new { id = game.Id }, game);
        }

        [HttpPut("{id:int}", Name = nameof(UpdateGame))]
        public async Task<IActionResult> UpdateGame(int id, Game game)
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
                if (!GameExists(id))
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

        [HttpDelete("{id:int}", Name = nameof(DeleteGame))]
        public async Task<ActionResult<Game>> DeleteGame(int id)
        {
            Game? game = await _context.Games.FindAsync(id);

            if (game is null)
            {
                return NotFound();
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            return game;
        }

        private bool GameExists(int id)
        {
            return _context.Games.Any(game => game.Id == id);
        }
    }
}
