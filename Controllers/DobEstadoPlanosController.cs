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
    public class DobEstadoPlanosController : ControllerBase
    {
        private readonly PlanosContext _context;

        public DobEstadoPlanosController(PlanosContext context)
        {
            _context = context;
        }

        // GET: api/DobEstadoPlanos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DobEstadoPlano>>> GetDobEstadoPlano()
        {
            return await _context.DobEstadoPlano.ToListAsync();
        }

        // GET: api/DobEstadoPlanos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DobEstadoPlano>> GetDobEstadoPlano(int id)
        {
            var dobEstadoPlano = await _context.DobEstadoPlano.FindAsync(id);

            if (dobEstadoPlano == null)
            {
                return NotFound();
            }

            return dobEstadoPlano;
        }

        // PUT: api/DobEstadoPlanos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDobEstadoPlano(int id, DobEstadoPlano dobEstadoPlano)
        {
            if (id != dobEstadoPlano.Id)
            {
                return BadRequest();
            }

            _context.Entry(dobEstadoPlano).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DobEstadoPlanoExists(id))
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

        // POST: api/DobEstadoPlanos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DobEstadoPlano>> PostDobEstadoPlano(DobEstadoPlano dobEstadoPlano)
        {
            _context.DobEstadoPlano.Add(dobEstadoPlano);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDobEstadoPlano", new { id = dobEstadoPlano.Id }, dobEstadoPlano);
        }

        // DELETE: api/DobEstadoPlanos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDobEstadoPlano(int id)
        {
            var dobEstadoPlano = await _context.DobEstadoPlano.FindAsync(id);
            if (dobEstadoPlano == null)
            {
                return NotFound();
            }

            _context.DobEstadoPlano.Remove(dobEstadoPlano);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DobEstadoPlanoExists(int id)
        {
            return _context.DobEstadoPlano.Any(e => e.Id == id);
        }
    }
}
