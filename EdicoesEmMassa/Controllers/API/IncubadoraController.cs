using EdicoesEmMassa.DataContext;
using EdicoesEmMassa.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdicoesEmMassa.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncubadoraController : ControllerBase
    {
        private readonly bancoContext _context;

        public IncubadoraController(bancoContext context)
        {
            _context = context;
        }

        // GET: api/Incubadora
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Incubadora>>> GetIncubadora()
        {
            return await _context.Incubadora.ToListAsync();
        }

        // GET: api/Incubadora/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Incubadora>> GetIncubadora(int id)
        {
            var incubadora = await _context.Incubadora.FindAsync(id);

            if (incubadora == null)
            {
                return NotFound();
            }

            return incubadora;
        }

        // PUT: api/Incubadora/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncubadora(int id, Incubadora incubadora)
        {
            if (id != incubadora.Id)
            {
                return BadRequest();
            }

            _context.Entry(incubadora).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncubadoraExists(id))
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

        // POST: api/Incubadora
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Incubadora>> PostIncubadora(Incubadora incubadora)
        {
            _context.Incubadora.Add(incubadora);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncubadora", new { id = incubadora.Id }, incubadora);
        }

        // DELETE: api/Incubadora/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncubadora(int id)
        {
            var incubadora = await _context.Incubadora.FindAsync(id);
            if (incubadora == null)
            {
                return NotFound();
            }

            _context.Incubadora.Remove(incubadora);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IncubadoraExists(int id)
        {
            return _context.Incubadora.Any(e => e.Id == id);
        }
    }
}
