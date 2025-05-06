using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlannerAPI.Models;

namespace PlannerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccommodationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AccommodationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accommodation>>> GetAccommodation()
        {
            return await _context.Accommodation.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Accommodation>> PostAccommodation(Accommodation accommodation)
        {
            _context.Accommodation.Add(accommodation);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAccommodation), new { id = accommodation.IDaccommodation }, accommodation);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Accommodation>> GetAccommodation(int id)
        {
            var entity = await _context.Accommodation.FindAsync(id);
            if (entity == null) return NotFound();
            return entity;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccommodation(int id)
        {
            var entity = await _context.Accommodation.FindAsync(id);
            if (entity == null) return NotFound();

            _context.Accommodation.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}