using EdicoesEmMassa.DataContext;
using EdicoesEmMassa.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EdicoesEmMassa.Controllers.Web
{
    public class TemperaturaHistoricosController : Controller
    {
        private readonly bancoContext _context;

        public TemperaturaHistoricosController(bancoContext context)
        {
            _context = context;
        }

        // GET: TemperaturaHistoricos
        public async Task<IActionResult> Index()
        {
            var bancoContext = _context.TemperaturaHistorico.Include(t => t.Incubadora);
            return View(await bancoContext.ToListAsync());
        }

        // GET: TemperaturaHistoricos/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.TemperaturaHistorico == null)
            {
                return NotFound();
            }

            var temperaturaHistorico = await _context.TemperaturaHistorico
                .Include(t => t.Incubadora)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (temperaturaHistorico == null)
            {
                return NotFound();
            }

            return View(temperaturaHistorico);
        }

        // GET: TemperaturaHistoricos/Create
        public IActionResult Create()
        {
            ViewData["IdIncubadora"] = new SelectList(_context.Incubadora, "Id", "Name");
            return View();
        }

        // POST: TemperaturaHistoricos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TemperaturaAtual,DataCriacao,IdIncubadora")] TemperaturaHistorico temperaturaHistorico)
        {
            if (ModelState.IsValid)
            {
                temperaturaHistorico.DataCriacao = DateTime.UtcNow.AddHours(-3);
                _context.Add(temperaturaHistorico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdIncubadora"] = new SelectList(_context.Incubadora, "Id", "Name", temperaturaHistorico.IdIncubadora);
            return View(temperaturaHistorico);
        }

        // GET: TemperaturaHistoricos/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.TemperaturaHistorico == null)
            {
                return NotFound();
            }

            var temperaturaHistorico = await _context.TemperaturaHistorico.FindAsync(id);
            if (temperaturaHistorico == null)
            {
                return NotFound();
            }
            ViewData["IdIncubadora"] = new SelectList(_context.Incubadora, "Id", "Name", temperaturaHistorico.IdIncubadora);
            return View(temperaturaHistorico);
        }

        // POST: TemperaturaHistoricos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,TemperaturaAtual,DataCriacao,IdIncubadora")] TemperaturaHistorico temperaturaHistorico)
        {
            if (id != temperaturaHistorico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    temperaturaHistorico.DataCriacao = DateTime.UtcNow.AddHours(-3);
                    _context.Update(temperaturaHistorico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TemperaturaHistoricoExists(temperaturaHistorico.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdIncubadora"] = new SelectList(_context.Incubadora, "Id", "Name", temperaturaHistorico.IdIncubadora);
            return View(temperaturaHistorico);
        }

        // GET: TemperaturaHistoricos/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.TemperaturaHistorico == null)
            {
                return NotFound();
            }

            var temperaturaHistorico = await _context.TemperaturaHistorico
                .Include(t => t.Incubadora)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (temperaturaHistorico == null)
            {
                return NotFound();
            }

            return View(temperaturaHistorico);
        }

        // POST: TemperaturaHistoricos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.TemperaturaHistorico == null)
            {
                return Problem("Entity set 'bancoContext.TemperaturaHistorico'  is null.");
            }
            var temperaturaHistorico = await _context.TemperaturaHistorico.FindAsync(id);
            if (temperaturaHistorico != null)
            {
                _context.TemperaturaHistorico.Remove(temperaturaHistorico);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TemperaturaHistoricoExists(long id)
        {
            return _context.TemperaturaHistorico.Any(e => e.Id == id);
        }
    }
}
