using HangmanGameAPI.Entities;
using HangmanGameAPI.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HangmanGameAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordsController : ControllerBase
    {
        private readonly HangmanGameContext _context;

        public WordsController(HangmanGameContext context)
        {
            _context = context;
        }

        [HttpGet(Name = nameof(GetWords))]
        public async Task<ActionResult<IEnumerable<Word>>> GetWords()
        {
            return await _context.Words.ToListAsync();
        }

        [HttpGet("{id:int}", Name = nameof(GetWord))]
        public async Task<ActionResult<Word>> GetWord(int id)
        {
            Word? word = await _context.Words.FindAsync(id);

            if (word is null)
            {
                return NotFound();
            }

            return word;
        }

        [HttpPost(Name = nameof(CreateWord))]
        public async Task<ActionResult<Word>> CreateWord(Word word)
        {
            _context.Words.Add(word);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWord", new { id = word.Id }, word);
        }

        [HttpPut("{id:int}", Name = nameof(UpdateWord))]
        public async Task<IActionResult> UpdateWord(int id, Word word)
        {
            if (id != word.Id)
            {
                return BadRequest();
            }

            _context.Entry(word).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WordExists(id))
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

        [HttpDelete("{id:int}", Name = nameof(DeleteWord))]
        public async Task<ActionResult<Word>> DeleteWord(int id)
        {
            Word? word = await _context.Words.FindAsync(id);

            if (word is null)
            {
                return NotFound();
            }

            _context.Words.Remove(word);
            await _context.SaveChangesAsync();

            return word;
        }

        private bool WordExists(int id)
        {
            return _context.Words.Any(word => word.Id == id);
        }
    }
}
