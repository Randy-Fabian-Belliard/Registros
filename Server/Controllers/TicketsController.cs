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
    public class TicketsController : ControllerBase
    {
        private readonly Context _context;

        public TicketsController(Context context)
        {
            _context = context;
        }

        // GET: api/Tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tickets>>> GetTickets()
        {
            if (_context.Tickets == null)
            {
                return NotFound();
            }
            return await _context.Tickets.ToListAsync();
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tickets>> GetTickets(int id)
        {
            if (_context.Tickets == null)
            {
                return NotFound();
            }
            var tickets = await _context.Tickets.FindAsync(id);

            if (tickets == null)
            {
                return NotFound();
            }

            return tickets;
        }

        // POST: api/Tickets
        [HttpPost]
        public async Task<ActionResult<Tickets>> PostTickets(Tickets tickets)
        {
            if (!TicketsExists(tickets.TicketsId))
                _context.Tickets.Add(tickets);
            else
                _context.Tickets.Update(tickets);

            await _context.SaveChangesAsync();
            return Ok(tickets);
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTickets(int id)
        {
            if (_context.Tickets == null)
            {
                return NotFound();
            }
            var tickets = await _context.Tickets.FindAsync(id);
            if (tickets == null)
            {
                return NotFound();
            }

            _context.Tickets.Remove(tickets);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketsExists(int id)
        {
            return (_context.Tickets?.Any(e => e.TicketsId == id)).GetValueOrDefault();
        }
    }
}

