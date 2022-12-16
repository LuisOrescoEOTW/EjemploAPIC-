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
    public class DobImpresionesPlanosController : ControllerBase
    {
        private readonly PlanosContext _context;

        public DobImpresionesPlanosController(PlanosContext context)
        {
            _context = context;
        }

        // GET: api/DobImpresionesPlanos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DobImpresionesPlanos>>> GetDobImpresionesPlanos()
        {
            return await _context.DobImpresionesPlanos.ToListAsync();
        }

        // GET: api/DobImpresionesPlanos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DobImpresionesPlanos>> GetDobImpresionesPlanos(int id)
        {
            var dobImpresionesPlanos = await _context.DobImpresionesPlanos.FindAsync(id);

            if (dobImpresionesPlanos == null)
            {
                return NotFound();
            }

            return dobImpresionesPlanos;
        }

        // PUT: api/DobImpresionesPlanos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDobImpresionesPlanos(int id, DobImpresionesPlanos dobImpresionesPlanos)
        {
            if (id != dobImpresionesPlanos.Id)
            {
                return BadRequest();
            }

            _context.Entry(dobImpresionesPlanos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DobImpresionesPlanosExists(id))
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

        // POST: api/DobImpresionesPlanos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DobImpresionesPlanos>> PostDobImpresionesPlanos(DobImpresionesPlanos dobImpresionesPlanos)
        {
            _context.DobImpresionesPlanos.Add(dobImpresionesPlanos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDobImpresionesPlanos", new { id = dobImpresionesPlanos.Id }, dobImpresionesPlanos);
        }

        // DELETE: api/DobImpresionesPlanos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDobImpresionesPlanos(int id)
        {
            var dobImpresionesPlanos = await _context.DobImpresionesPlanos.FindAsync(id);
            if (dobImpresionesPlanos == null)
            {
                return NotFound();
            }

            _context.DobImpresionesPlanos.Remove(dobImpresionesPlanos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DobImpresionesPlanosExists(int id)
        {
            return _context.DobImpresionesPlanos.Any(e => e.Id == id);
        }
    }
}
