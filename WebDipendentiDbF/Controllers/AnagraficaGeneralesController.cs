using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebDipendentiDbF.BLogic.Authentication;
using WebDipendentiDbF.Models;

namespace WebDipendentiDbF.Controllers
{
    //[BasicAuthenticationAttributes]
    [Route("api/[controller]")]
    [ApiController]
    public class AnagraficaGeneralesController : ControllerBase
    {
        private readonly DatabaseDipendentiContext _context;

        public AnagraficaGeneralesController(DatabaseDipendentiContext context)
        {
            _context = context;
        }

        // GET: api/AnagraficaGenerales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnagraficaGenerale>>> GetAnagraficaGenerales()
        {
          if (_context.AnagraficaGenerales == null)
          {
              return NotFound();
          }
            return await _context.AnagraficaGenerales.Include(emp => emp.AttivitaDipendentes).ToListAsync();
        }

        // GET: api/AnagraficaGenerales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnagraficaGenerale>> GetAnagraficaGenerale(string id)
        {
          if (_context.AnagraficaGenerales == null)
          {
              return NotFound();
          }
            var anagraficaGenerale = await _context.AnagraficaGenerales.Include(emp => emp.AttivitaDipendentes).FirstOrDefaultAsync(emp => emp.Matricola == id);

            if (anagraficaGenerale == null)
            {
                return NotFound();
            }

            return anagraficaGenerale;
        }

        // PUT: api/AnagraficaGenerales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnagraficaGenerale(string id, AnagraficaGenerale anagraficaGenerale)
        {
            if (id != anagraficaGenerale.Matricola)
            {
                return BadRequest();
            }

            _context.Entry(anagraficaGenerale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnagraficaGeneraleExists(id))
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

        // POST: api/AnagraficaGenerales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnagraficaGenerale>> PostAnagraficaGenerale(AnagraficaGenerale anagraficaGenerale)
        {
          if (_context.AnagraficaGenerales == null)
          {
              return Problem("Entity set 'DatabaseDipendentiContext.AnagraficaGenerales'  is null.");
          }
            _context.AnagraficaGenerales.Add(anagraficaGenerale);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AnagraficaGeneraleExists(anagraficaGenerale.Matricola))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAnagraficaGenerale", new { id = anagraficaGenerale.Matricola }, anagraficaGenerale);
        }

        // DELETE: api/AnagraficaGenerales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnagraficaGenerale(string id)
        {
            if (_context.AnagraficaGenerales == null)
            {
                return NotFound();
            }
            var anagraficaGenerale = await _context.AnagraficaGenerales.Include(emp=> emp.AttivitaDipendentes).FirstOrDefaultAsync(emp => emp.Matricola == id);
            if (anagraficaGenerale == null)
            {
                return NotFound();
            }

            _context.AnagraficaGenerales.RemoveRange(anagraficaGenerale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnagraficaGeneraleExists(string id)
        {
            return (_context.AnagraficaGenerales?.Any(e => e.Matricola == id)).GetValueOrDefault();
        }
    }
}
