using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebDipendentiDbF.Models;

namespace WebDipendentiDbF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyUsersController : ControllerBase
    {
        private readonly DatabaseDipendentiContext _context;

        public MyUsersController(DatabaseDipendentiContext context)
        {
            _context = context;
        }

        // GET: api/MyUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyUser>>> GetMyUser()
        {
          if (_context.MyUser == null)
          {
              return NotFound();
          }
            return await _context.MyUser.ToListAsync();
        }

        // GET: api/MyUsers/5
        [HttpGet("{email}")]
        public async Task<ActionResult<MyUser>> GetMyUser(string email)
        {
          if (_context.MyUser == null)
          {
              return NotFound();
          }
            var myUser = await _context.MyUser.Where(e => e.Email == email).FirstOrDefaultAsync();

            if (myUser == null)
            {
                return NotFound();
            }

            return myUser;
        }

        // PUT: api/MyUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyUser(int id, MyUser myUser)
        {
            if (id != myUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(myUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyUserExists(id))
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

        // POST: api/MyUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MyUser>> PostMyUser(MyUser myUser)
        {
          if (_context.MyUser == null)
          {
              return Problem("Entity set 'DatabaseDipendentiContext.MyUser'  is null.");
          }
            _context.MyUser.Add(myUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMyUser", new { id = myUser.Id }, myUser);
        }

        // DELETE: api/MyUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMyUser(int id)
        {
            if (_context.MyUser == null)
            {
                return NotFound();
            }
            var myUser = await _context.MyUser.FindAsync(id);
            if (myUser == null)
            {
                return NotFound();
            }

            _context.MyUser.Remove(myUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MyUserExists(int id)
        {
            return (_context.MyUser?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
