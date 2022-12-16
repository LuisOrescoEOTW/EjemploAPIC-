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
    public class DobPlanosController : ControllerBase
    {
        private readonly PlanosContext _context;

        public DobPlanosController(PlanosContext context)
        {
            _context = context;
        }

        // GET: api/DobPlanos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DobPlano>>> GetDobPlano()
        {
            return await _context.DobPlano.ToListAsync();
        }

        // GET: api/DobPlanos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DobPlano>> GetDobPlano(int id)
        {
            var dobPlano = await _context.DobPlano.FindAsync(id);

            if (dobPlano == null)
            {
                return NotFound();
            }

            return dobPlano;
        }

        // PUT: api/DobPlanos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDobPlano(int id, DobPlano dobPlano)
        {
            if (id != dobPlano.Id)
            {
                return BadRequest();
            }

            _context.Entry(dobPlano).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DobPlanoExists(id))
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

        // POST: api/DobPlanos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DobPlano>> PostDobPlano(DobPlano dobPlano)
        {
            _context.DobPlano.Add(dobPlano);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDobPlano", new { id = dobPlano.Id }, dobPlano);
        }

        // DELETE: api/DobPlanos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDobPlano(int id)
        {
            var dobPlano = await _context.DobPlano.FindAsync(id);
            if (dobPlano == null)
            {
                return NotFound();
            }

            _context.DobPlano.Remove(dobPlano);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DobPlanoExists(int id)
        {
            return _context.DobPlano.Any(e => e.Id == id);
        }
    }
}
