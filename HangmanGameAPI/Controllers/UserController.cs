using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HangmanGameAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HangmanGameAPI.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly HangmanGameContext hangmanGameContext;

        public UserController(HangmanGameContext context)
        {
            hangmanGameContext = context;

            if (hangmanGameContext.Users.Count() == 0)
            {
                User user = new User
                {
                    Username = "admin",
                    Email = "alexandra.valkova.97@gmail.com",
                    Password = "1234"
                };
                hangmanGameContext.Users.Add(user);
                hangmanGameContext.SaveChanges();
            }
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersAsync()
        {
            return await hangmanGameContext.Users.ToListAsync();
        }

        // GET api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserAsync(int id)
        {
            User user = await hangmanGameContext.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST api/User
        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody]User user)
        {
            hangmanGameContext.Users.Add(user);
            await hangmanGameContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserAsync), new { id = user.Id }, user);
        }

        // PUT api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, [FromBody]User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            hangmanGameContext.Entry(user).State = EntityState.Modified;
            await hangmanGameContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            User user = await hangmanGameContext.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            hangmanGameContext.Users.Remove(user);
            await hangmanGameContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
