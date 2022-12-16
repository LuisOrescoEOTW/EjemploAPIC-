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
    public class DobUsuariosController : ControllerBase
    {
        private readonly PlanosContext _context;

        public DobUsuariosController(PlanosContext context)
        {
            _context = context;
        }

        // GET: api/DobUsuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DobUsuario>>> GetDobUsuario()
        {
            return await _context.DobUsuario.ToListAsync();
        }

        // GET: api/DobUsuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DobUsuario>> GetDobUsuario(int id)
        {
            var dobUsuario = await _context.DobUsuario.FindAsync(id);

            if (dobUsuario == null)
            {
                return NotFound();
            }

            return dobUsuario;
        }

        // PUT: api/DobUsuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDobUsuario(int id, DobUsuario dobUsuario)
        {
            if (id != dobUsuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(dobUsuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DobUsuarioExists(id))
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

        // POST: api/DobUsuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DobUsuario>> PostDobUsuario(DobUsuario dobUsuario)
        {
            _context.DobUsuario.Add(dobUsuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDobUsuario", new { id = dobUsuario.Id }, dobUsuario);
        }

        // DELETE: api/DobUsuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDobUsuario(int id)
        {
            var dobUsuario = await _context.DobUsuario.FindAsync(id);
            if (dobUsuario == null)
            {
                return NotFound();
            }

            _context.DobUsuario.Remove(dobUsuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DobUsuarioExists(int id)
        {
            return _context.DobUsuario.Any(e => e.Id == id);
        }
    }
}
