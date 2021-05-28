using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APICard.Data;

namespace APICard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCredCardsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserCredCardsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UserCredCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCredCard>>> GetUserCredCards()
        {
            return await _context.UserCredCards.ToListAsync();
        }

        // GET: api/UserCredCards/5
        [HttpGet("{Email}")]
        public async Task<ActionResult<List<UserCredCard>>> GetUsuario(String Email)
        {
            var userCredCard = await _context.UserCredCards.Where(x => x.Email == Email).ToListAsync();

            if (userCredCard == null)
            {
                return NotFound();
            }

            return userCredCard;
        }

        // PUT: api/UserCredCards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserCredCard(int id, UserCredCard userCredCard)
        {
            if (id != userCredCard.Id)
            {
                return BadRequest();
            }

            _context.Entry(userCredCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserCredCardExists(id))
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

        // POST: api/UserCredCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<string> PostUserCredCardAsync(String userCredCard)
        {
            UserCredCard usercredcard1 = new UserCredCard();
            Random randNum = new Random();
            int b = randNum.Next(100, 999);
            Random randNum1 = new Random();
            int c = randNum1.Next(100, 999);
            Random randNum2 = new Random();
            int d = randNum2.Next(100, 999);
            Random randNum3 = new Random();
            int f = randNum3.Next(100, 999);
            string g = "" + b + "" + c + "" + d + "" + f;
            usercredcard1.SetCard(g);
            usercredcard1.SetEmail(userCredCard);
            _context.UserCredCards.Add(usercredcard1);
            await _context.SaveChangesAsync();

            return usercredcard1.Email;
        }

        // DELETE: api/UserCredCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserCredCard(int id)
        {
            var userCredCard = await _context.UserCredCards.FindAsync(id);
            if (userCredCard == null)
            {
                return NotFound();
            }

            _context.UserCredCards.Remove(userCredCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserCredCardExists(int id)
        {
            return _context.UserCredCards.Any(e => e.Id == id);
        }
    }
}
