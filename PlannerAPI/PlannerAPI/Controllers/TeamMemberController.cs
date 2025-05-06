using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlannerAPI.Models;

namespace PlannerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMemberController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TeamMemberController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamMember>>> GetTeamMember()
        {
            return await _context.TeamMember.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<TeamMember>> PostTeamMember(TeamMember teamMember)
        {
            _context.TeamMember.Add(teamMember);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTeamMember), new { id = teamMember.IDteam }, teamMember);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeamMember>> GetTeamMember(int id)
        {
            var entity = await _context.TeamMember.FindAsync(id);
            if (entity == null) return NotFound();
            return entity;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamMember(int id)
        {
            var entity = await _context.TeamMember.FindAsync(id);
            if (entity == null) return NotFound();

            _context.TeamMember.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
