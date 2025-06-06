using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        // GET: api/TripUser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripUser>>> GetTripUser()
        {
            return await _context.TripUser
                .Include(tu => tu.User)
                .Include(tu => tu.Trip)
                .ToListAsync();
        }

        // GET: api/TripUser/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TripUser>> GetTripUser(int id)
        {
            var tripUser = await _context.TripUser
                .Include(t => t.User)
                .Include(t => t.Trip)
                .FirstOrDefaultAsync(t => t.IDtripUser == id);

            if (tripUser == null)
            {
                return NotFound();
            }

            return tripUser;
        }

        // PUT: api/TripUser/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTripUser(int id, [FromBody] TripUserDto dto)
        {
            if (id != dto.IDtripUser)
                return BadRequest();

            Console.WriteLine($"PUT TripUser: ID={dto.IDtripUser}, IDuser={dto.IDuser}, IDtrip={dto.IDtrip}, joinDate={dto.JoinDate}");

            var tripUser = await _context.TripUser.FindAsync(id);
            if (tripUser == null)
                return NotFound();

            tripUser.IDuser = dto.IDuser;
            tripUser.IDtrip = dto.IDtrip;
            tripUser.JoinDate = dto.JoinDate;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/TripUser
        [HttpPost]
        public async Task<ActionResult<TripUser>> PostTripUser([FromBody] TripUserDto dto)
        {
            Console.WriteLine($"POST TripUser: IDuser={dto.IDuser}, IDtrip={dto.IDtrip}, joinDate={dto.JoinDate}");

            var tripUser = new TripUser
            {
                IDuser = dto.IDuser,
                IDtrip = dto.IDtrip,
                JoinDate = dto.JoinDate
            };

            _context.TripUser.Add(tripUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTripUser), new { id = tripUser.IDtripUser }, tripUser);
        }

        // DELETE: api/TripUser/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTripUser(int id)
        {
            var tripUser = await _context.TripUser.FindAsync(id);
            if (tripUser == null)
                return NotFound();

            _context.TripUser.Remove(tripUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TripUserExists(int id)
        {
            return _context.TripUser.Any(e => e.IDtripUser == id);
        }
    }

    // DTO bez User i Trip (które są powodami błędów walidacji)
    public class TripUserDto
    {
        public int IDtripUser { get; set; }
        public int IDuser { get; set; }
        public int IDtrip { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
