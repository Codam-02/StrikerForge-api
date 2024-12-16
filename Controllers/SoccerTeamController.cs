using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StrikerForge.models;

namespace StrikerForge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoccerTeamController : ControllerBase
    {
        private readonly StrikerForgeDbContext _context;

        public SoccerTeamController(StrikerForgeDbContext context)
        {
            _context = context;
        }

        // GET: api/SoccerTeam
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SoccerTeam>>> GetTeams()
        {
            return await _context.Teams.ToListAsync();
        }

        // GET: api/SoccerTeam/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SoccerTeam>> GetSoccerTeam(int id)
        {
            var soccerTeam = await _context.Teams.FindAsync(id);

            if (soccerTeam == null)
            {
                return NotFound();
            }

            return soccerTeam;
        }

        // PUT: api/SoccerTeam/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoccerTeam(int id, SoccerTeam soccerTeam)
        {
            if (id != soccerTeam.Id)
            {
                return BadRequest();
            }

            _context.Entry(soccerTeam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoccerTeamExists(id))
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

        // POST: api/SoccerTeam
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SoccerTeam>> PostSoccerTeam(SoccerTeam soccerTeam)
        {
            _context.Teams.Add(soccerTeam);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSoccerTeam), new { id = soccerTeam.Id }, soccerTeam);
        }

        // DELETE: api/SoccerTeam/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoccerTeam(int id)
        {
            var soccerTeam = await _context.Teams.FindAsync(id);
            if (soccerTeam == null)
            {
                return NotFound();
            }

            _context.Teams.Remove(soccerTeam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SoccerTeamExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }
    }
}
