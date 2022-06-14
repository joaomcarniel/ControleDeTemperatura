using EdicoesEmMassa.DataContext;
using EdicoesEmMassa.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EdicoesEmMassa.Controllers.Web
{
    public class IncubadorasController : Controller
    {
        private readonly bancoContext _context;

        public IncubadorasController(bancoContext context)
        {
            _context = context;
        }

        // GET: Incubadoras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Incubadora.ToListAsync());
        }

        // GET: Incubadoras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Incubadora == null)
            {
                return NotFound();
            }

            var incubadora = await _context.Incubadora
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incubadora == null)
            {
                return NotFound();
            }

            return View(incubadora);
        }

        // GET: Incubadoras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Incubadoras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,TemperaturaIdeal,TemperaturaAtual,DataCriacao")] Incubadora incubadora)
        {
            if (ModelState.IsValid)
            {
                incubadora.DataCriacao = DateTime.UtcNow.AddHours(-3);
                _context.Add(incubadora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(incubadora);
        }

        // GET: Incubadoras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Incubadora == null)
            {
                return NotFound();
            }

            var incubadora = await _context.Incubadora.FindAsync(id);
            if (incubadora == null)
            {
                return NotFound();
            }
            return View(incubadora);
        }

        // POST: Incubadoras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,TemperaturaIdeal,TemperaturaAtual,DataCriacao")] Incubadora incubadora)
        {
            if (id != incubadora.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    incubadora.DataCriacao = DateTime.UtcNow.AddHours(-3);
                    _context.Update(incubadora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncubadoraExists(incubadora.Id))
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
            return View(incubadora);
        }

        // GET: Incubadoras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Incubadora == null)
            {
                return NotFound();
            }

            var incubadora = await _context.Incubadora
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incubadora == null)
            {
                return NotFound();
            }

            return View(incubadora);
        }

        // POST: Incubadoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Incubadora == null)
            {
                return Problem("Entity set 'bancoContext.Incubadora'  is null.");
            }
            var incubadora = await _context.Incubadora.FindAsync(id);
            if (incubadora != null)
            {
                _context.Incubadora.Remove(incubadora);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncubadoraExists(int id)
        {
            return _context.Incubadora.Any(e => e.Id == id);
        }
    }
}
