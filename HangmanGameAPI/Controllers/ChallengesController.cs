using HangmanGameAPI.Entities;
using HangmanGameAPI.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HangmanGameAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChallengesController : ControllerBase
    {
        private readonly HangmanGameContext _context;

        public ChallengesController(HangmanGameContext context)
        {
            _context = context;
        }

        [HttpGet(Name = nameof(GetChallenges))]
        public async Task<ActionResult<IEnumerable<Challenge>>> GetChallenges()
        {
            return await _context.Challenges.ToListAsync();
        }

        [HttpGet("{id:int}", Name = nameof(GetChallenge))]
        public async Task<ActionResult<Challenge>> GetChallenge(int id)
        {
            Challenge? challenge = await _context.Challenges.FindAsync(id);

            if (challenge is null)
            {
                return NotFound();
            }

            return challenge;
        }

        [HttpPost(Name = nameof(CreateChallenge))]
        public async Task<ActionResult<Challenge>> CreateChallenge(Challenge challenge)
        {
            _context.Challenges.Add(challenge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChallenge", new { id = challenge.GameId }, challenge);
        }

        [HttpPut("{id:int}", Name = nameof(UpdateChallenge))]
        public async Task<IActionResult> UpdateChallenge(int id, Challenge challenge)
        {
            if (id != challenge.GameId)
            {
                return BadRequest();
            }

            _context.Entry(challenge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChallengeExists(id))
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

        [HttpDelete("{id:int}", Name = nameof(DeleteChallenge))]
        public async Task<ActionResult<Challenge>> DeleteChallenge(int id)
        {
            Challenge? challenge = await _context.Challenges.FindAsync(id);

            if (challenge is null)
            {
                return NotFound();
            }

            _context.Challenges.Remove(challenge);
            await _context.SaveChangesAsync();

            return challenge;
        }

        private bool ChallengeExists(int id)
        {
            return _context.Challenges.Any(challenge => challenge.GameId == id);
        }
    }
}
