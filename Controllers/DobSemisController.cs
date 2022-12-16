using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Planos.Models;

namespace Planos.Controllers
{
    [Route("api/1.0/[controller]")]
    [ApiController]
    public class DobSemisController : ControllerBase
    {
        private readonly PlanosContext _context;

        public DobSemisController(PlanosContext context)
        {
            _context = context;
        }

        // GET: api/DobSemis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DobSemi>>> GetDobSemi()
        {
            return await _context.DobSemi.ToListAsync();
        }

        // GET: api/DobSemis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DobSemi>> GetDobSemi(int id)
        {
            var dobSemi = await _context.DobSemi.FindAsync(id);

            if (dobSemi == null)
            {
                return NotFound();
            }

            return dobSemi;
        }

        // PUT: api/DobSemis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDobSemi(int id, DobSemi dobSemi)
        {
            if (id != dobSemi.Id)
            {
                return BadRequest();
            }

            _context.Entry(dobSemi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DobSemiExists(id))
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

        // POST: api/DobSemis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DobSemi>> PostDobSemi(DobSemi dobSemi)
        {
            _context.DobSemi.Add(dobSemi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDobSemi", new { id = dobSemi.Id }, dobSemi);
        }

        // DELETE: api/DobSemis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDobSemi(int id)
        {
            var dobSemi = await _context.DobSemi.FindAsync(id);
            if (dobSemi == null)
            {
                return NotFound();
            }

            _context.DobSemi.Remove(dobSemi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DobSemiExists(int id)
        {
            return _context.DobSemi.Any(e => e.Id == id);
        }
    }
}
