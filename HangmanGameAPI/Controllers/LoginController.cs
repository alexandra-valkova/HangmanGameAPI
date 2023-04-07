using HangmanGameAPI.Data;
using HangmanGameAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HangmanGameAPI.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly HangmanGameContext _context;

        public LoginController(HangmanGameContext context)
        {
            _context = context;
        }

        // GET: api/Login?username=&password=
        [HttpGet]
        public async Task<ActionResult<User>> Login(string username, string password)
        {
            User user = _context.Users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();

            if (user != null)
            {
                return user;
            }

            return NotFound();
        }
    }
}