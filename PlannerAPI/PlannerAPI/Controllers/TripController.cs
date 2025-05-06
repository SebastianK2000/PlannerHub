using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlannerAPI.Models;

namespace PlannerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TripController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trip>>> GetTrip()
        {
            return await _context.Trip.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Trip>> PostTrip(Trip trip)
        {
            _context.Trip.Add(trip);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTrip), new { id = trip.IDtrip }, trip);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Trip>> GetTrip(int id)
        {
            var entity = await _context.Trip.FindAsync(id);
            if (entity == null) return NotFound();
            return entity;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrip(int id)
        {
            var entity = await _context.Trip.FindAsync(id);
            if (entity == null) return NotFound();

            _context.Trip.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}