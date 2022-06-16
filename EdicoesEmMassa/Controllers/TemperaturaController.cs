using EdicoesEmMassa.DataContext;
using EdicoesEmMassa.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdicoesEmMassa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperaturaController : ControllerBase
    {
        private readonly bancoContext _context;

        public TemperaturaController(bancoContext context)
        {
            _context = context;
        }

        // GET: api/Temperatura
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TemperaturaModel>>> GetTemperatura()
        {
            return await _context.Temperatura.ToListAsync();
        }

        // GET: api/Temperatura/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TemperaturaModel>> GetTemperaturaModel(int id)
        {
            var temperaturaModel = await _context.Temperatura.FindAsync(id);

            if (temperaturaModel == null)
            {
                return NotFound();
            }

            return temperaturaModel;
        }

        // PUT: api/Temperatura/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTemperaturaModel(int id, TemperaturaModel temperaturaModel)
        {
            if (id != temperaturaModel.IdTemperatura)
            {
                return BadRequest();
            }

            _context.Entry(temperaturaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemperaturaModelExists(id))
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

        // POST: api/Temperatura
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TemperaturaModel>> PostTemperaturaModel(TemperaturaModel temperaturaModel)
        {
            _context.Temperatura.Add(temperaturaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTemperaturaModel", new { id = temperaturaModel.IdTemperatura }, temperaturaModel);
        }

        // DELETE: api/Temperatura/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTemperaturaModel(int id)
        {
            var temperaturaModel = await _context.Temperatura.FindAsync(id);
            if (temperaturaModel == null)
            {
                return NotFound();
            }

            _context.Temperatura.Remove(temperaturaModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TemperaturaModelExists(int id)
        {
            return _context.Temperatura.Any(e => e.IdTemperatura == id);
        }
    }
}
