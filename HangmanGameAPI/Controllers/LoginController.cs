using HangmanGameAPI.Entities;
using HangmanGameAPI.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace HangmanGameAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly HangmanGameContext _context;

        public LoginController(HangmanGameContext context)
        {
            _context = context;
        }

        [HttpGet(Name = nameof(Login))]
        public ActionResult<User> Login(string username, string password)
        {
            User? user = _context.Users.Where(user => user.Username == username && user.Password == password)
                                       .FirstOrDefault();

            if (user is null)
            {
                return NotFound();
            }

            return user;
        }
    }
}