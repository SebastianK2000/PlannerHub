using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlannerAPI.Models;
using PlannerAPI.Models.PlannerAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        // GET: api/Accommodations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accommodation>>> GetAccommodation()
        {
            return await _context.Accommodation
                .Include(a => a.User)
                .ToListAsync();
        }

        // GET: api/Accommodation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Accommodation>> GetAccommodation(int id)
        {
            var accommodation = await _context.Accommodation
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.IDaccommodation == id);

            if (accommodation == null)
                return NotFound();

            return accommodation;
        }


        // PUT: api/Accommodations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccommodation(int id, [FromBody] AccommodationDto dto)
        {
            var accommodation = await _context.Accommodation.FindAsync(id);
            if (accommodation == null)
                return NotFound();

            accommodation.IDuser = dto.IDuser;
            accommodation.Name = dto.Name;
            accommodation.Type = dto.Type;
            accommodation.Address = dto.Address;
            accommodation.Price = dto.Price;
            accommodation.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return NoContent();
        }


        // POST: api/Accommodations
        [HttpPost]
        public async Task<ActionResult<Accommodation>> PostAccommodation([FromBody] AccommodationDto dto)
        {
            var accommodation = new Accommodation
            {
                IDuser = dto.IDuser,
                Name = dto.Name,
                Type = dto.Type,
                Address = dto.Address,
                Price = dto.Price,
                CreatedAt = dto.Date,
                UpdatedAt = DateTime.Now,
            };

            _context.Accommodation.Add(accommodation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAccommodation), new { id = accommodation.IDaccommodation }, accommodation);
        }


        // DELETE: api/Accommodations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccommodation(int id)
        {
            var accommodation = await _context.Accommodation.FindAsync(id);
            if (accommodation == null)
            {
                return NotFound();
            }

            _context.Accommodation.Remove(accommodation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccommodationExists(int id)
        {
            return _context.Accommodation.Any(e => e.IDaccommodation == id);
        }
    }
}
