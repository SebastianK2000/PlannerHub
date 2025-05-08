using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlannerAPI.Models;

namespace PlannerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripUserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TripUserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TripUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripUser>>> GetTripUser()
        {
            return await _context.TripUser.ToListAsync();
        }

        // GET: api/TripUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TripUser>> GetTripUser(int id)
        {
            var tripUser = await _context.TripUser.FindAsync(id);

            if (tripUser == null)
            {
                return NotFound();
            }

            return tripUser;
        }

        // PUT: api/TripUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTripUser(int id, TripUser tripUser)
        {
            if (id != tripUser.IDtripUser)
            {
                return BadRequest();
            }

            _context.Entry(tripUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TripUserExists(id))
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

        // POST: api/TripUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TripUser>> PostTripUser(TripUser tripUser)
        {
            _context.TripUser.Add(tripUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTripUser", new { id = tripUser.IDtripUser }, tripUser);
        }

        // DELETE: api/TripUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTripUser(int id)
        {
            var tripUser = await _context.TripUser.FindAsync(id);
            if (tripUser == null)
            {
                return NotFound();
            }

            _context.TripUser.Remove(tripUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TripUserExists(int id)
        {
            return _context.TripUser.Any(e => e.IDtripUser == id);
        }
    }
}
