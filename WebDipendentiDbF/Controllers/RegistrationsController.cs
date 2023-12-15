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
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private readonly DatabaseDipendentiContext _context;

        public RegistrationsController(DatabaseDipendentiContext context)
        {
            _context = context;
        }

        
        [HttpPost]
        public async Task<ActionResult<MyUser>> PostRegistration(MyUser registration)
        {
          if (_context.Registration == null)
          {
              return Problem("Entity set 'DatabaseDipendentiContext.Registration'  is null.");
          }
            _context.Registration.Add(registration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistration", new { id = registration.Id }, registration);
        }
    }
}
