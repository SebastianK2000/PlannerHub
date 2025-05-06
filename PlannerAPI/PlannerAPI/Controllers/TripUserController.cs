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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripUser>>> GetTripUser()
        {
            return await _context.TripUser.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<TripUser>> PostTripUser(TripUser tripuser)
        {
            _context.TripUser.Add(tripuser);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTripUser), new { id = tripuser.IDtrip }, tripuser);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TripUser>> GetTripUser(int id)
        {
            var entity = await _context.TripUser.FindAsync(id);
            if (entity == null) return NotFound();
            return entity;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTripUser(int id)
        {
            var entity = await _context.TripUser.FindAsync(id);
            if (entity == null) return NotFound();

            _context.TripUser.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}