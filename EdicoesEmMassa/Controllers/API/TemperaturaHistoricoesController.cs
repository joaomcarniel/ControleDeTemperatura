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
    public class TemperaturaHistoricoesController : ControllerBase
    {
        private readonly bancoContext _context;

        public TemperaturaHistoricoesController(bancoContext context)
        {
            _context = context;
        }

        // GET: api/TemperaturaHistoricoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TemperaturaHistorico>>> GetTemperaturaHistorico()
        {
            return await _context.TemperaturaHistorico.ToListAsync();
        }

        // GET: api/TemperaturaHistoricoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TemperaturaHistorico>> GetTemperaturaHistorico(long id)
        {
            var temperaturaHistorico = await _context.TemperaturaHistorico.FindAsync(id);

            if (temperaturaHistorico == null)
            {
                return NotFound();
            }

            return temperaturaHistorico;
        }

        // PUT: api/TemperaturaHistoricoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTemperaturaHistorico(long id, TemperaturaHistorico temperaturaHistorico)
        {
            if (id != temperaturaHistorico.Id)
            {
                return BadRequest();
            }

            _context.Entry(temperaturaHistorico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemperaturaHistoricoExists(id))
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

        // POST: api/TemperaturaHistoricoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TemperaturaHistorico>> PostTemperaturaHistorico(TemperaturaHistorico temperaturaHistorico)
        {
            _context.TemperaturaHistorico.Add(temperaturaHistorico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTemperaturaHistorico", new { id = temperaturaHistorico.Id }, temperaturaHistorico);
        }

        // DELETE: api/TemperaturaHistoricoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTemperaturaHistorico(long id)
        {
            var temperaturaHistorico = await _context.TemperaturaHistorico.FindAsync(id);
            if (temperaturaHistorico == null)
            {
                return NotFound();
            }

            _context.TemperaturaHistorico.Remove(temperaturaHistorico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TemperaturaHistoricoExists(long id)
        {
            return _context.TemperaturaHistorico.Any(e => e.Id == id);
        }
    }
}
