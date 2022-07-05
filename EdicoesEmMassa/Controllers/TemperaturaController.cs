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
        private readonly jupiterContext _context;

        public TemperaturaController(jupiterContext context)
        {
            _context = context;
        }

        // GET: api/Temperatura
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Temperatura>>> GetTemperatura()
        {
            return await _context.Temperaturas.ToListAsync();
        }

        // GET: api/Temperatura/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Temperatura>> GetTemperatura(int id)
        {
            var Temperatura = await _context.Temperaturas.FindAsync(id);

            if (Temperatura == null)
            {
                return NotFound();
            }

            return Temperatura;
        }

        // PUT: api/Temperatura/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTemperatura(int id, Temperatura Temperatura)
        {
            if (id != Temperatura.id_temperatura)
            {
                return BadRequest();
            }

            _context.Entry(Temperatura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemperaturaExists(id))
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
        public async Task<ActionResult<Temperatura>> PostTemperatura(Temperatura Temperatura)
        {
            _context.Temperaturas.Add(Temperatura);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTemperatura", new { id = Temperatura.id_temperatura }, Temperatura);
        }

        // DELETE: api/Temperatura/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTemperatura(int id)
        {
            var Temperatura = await _context.Temperaturas.FindAsync(id);
            if (Temperatura == null)
            {
                return NotFound();
            }

            _context.Temperaturas.Remove(Temperatura);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TemperaturaExists(int id)
        {
            return _context.Temperaturas.Any(e => e.id_temperatura == id);
        }
    }
}
