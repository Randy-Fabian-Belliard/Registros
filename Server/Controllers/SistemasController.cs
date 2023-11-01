using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistrosWeb.Server.DAL;
using RegistrosWeb.Shared.Models;

namespace RegistrosWeb.Server.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class SistemasController : ControllerBase
    {
        private readonly Context _context;

        public SistemasController(Context context)
        {
            _context = context;
        }

        // GET: api/Sistemas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sistemas>>> GetSistemas()
        {
            if (_context.Sistemas == null)
            {
                return NotFound();
            }
            return await _context.Sistemas.ToListAsync();
        }

        // GET: api/Sistemas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sistemas>> GetSistemas(int id)
        {
            if (_context.Sistemas == null)
            {
                return NotFound();
            }
            var sistemas = await _context.Sistemas.FindAsync(id);

            if (sistemas == null)
            {
                return NotFound();
            }

            return sistemas;
        }

        // POST: api/Sistemas
        [HttpPost]
        public async Task<ActionResult<Sistemas>> PostSistemas(Sistemas sistemas)
        {
            if (!SistemasExists(sistemas.SistemaId))
                _context.Sistemas.Add(sistemas);
            else
                _context.Sistemas.Update(sistemas);

            await _context.SaveChangesAsync();
            return Ok(sistemas);
        }

        // DELETE: api/Sistemas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSistemas(int id)
        {
            if (_context.Sistemas == null)
            {
                return NotFound();
            }
            var sistemas = await _context.Sistemas.FindAsync(id);
            if (sistemas == null)
            {
                return NotFound();
            }

            _context.Sistemas.Remove(sistemas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SistemasExists(int id)
        {
            return (_context.Sistemas?.Any(e => e.SistemaId == id)).GetValueOrDefault();
        }
    }
}
