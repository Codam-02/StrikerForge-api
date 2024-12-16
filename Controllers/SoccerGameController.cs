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
    public class SoccerGameController : ControllerBase
    {
        private readonly StrikerForgeDbContext _context;

        public SoccerGameController(StrikerForgeDbContext context)
        {
            _context = context;
        }

        // GET: api/SoccerGame
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SoccerGame>>> GetSoccerGames()
        {
            return await _context.SoccerGames.ToListAsync();
        }

        // GET: api/SoccerGame/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SoccerGame>> GetSoccerGame(int id)
        {
            var soccerGame = await _context.SoccerGames.FindAsync(id);

            if (soccerGame == null)
            {
                return NotFound();
            }

            return soccerGame;
        }

        // PUT: api/SoccerGame/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoccerGame(int id, SoccerGame soccerGame)
        {
            if (id != soccerGame.Id)
            {
                return BadRequest();
            }

            _context.Entry(soccerGame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoccerGameExists(id))
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

        // POST: api/SoccerGame
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SoccerGame>> PostSoccerGame(SoccerGame soccerGame)
        {
            _context.SoccerGames.Add(soccerGame);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSoccerGame", new { id = soccerGame.Id }, soccerGame);
        }

        // DELETE: api/SoccerGame/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoccerGame(int id)
        {
            var soccerGame = await _context.SoccerGames.FindAsync(id);
            if (soccerGame == null)
            {
                return NotFound();
            }

            _context.SoccerGames.Remove(soccerGame);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SoccerGameExists(int id)
        {
            return _context.SoccerGames.Any(e => e.Id == id);
        }
    }
}
