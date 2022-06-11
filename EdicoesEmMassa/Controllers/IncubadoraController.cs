using EdicoesEmMassa.Model;
using EdicoesEmMassa.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EdicoesEmMassa.Controllers
{
    public class IncubadoraController : Controller
    {
        private readonly IIncubadoraRepository _incubadoraRepository;

        public IncubadoraController(IIncubadoraRepository incubadoraRepository)
        {
            _incubadoraRepository = incubadoraRepository;
        }
        public IActionResult Index()
        {
            var incubadoras = _incubadoraRepository.GetAll();
            return View(incubadoras);
        }

        public IActionResult Creating()
        {
            return View();
        }

        public IActionResult Update(int id)
        {
            var Incubadora = _incubadoraRepository.GetById(id);
            return View(Incubadora);
        }

        public IActionResult ConfirmDelete(int id)
        {
            var Incubadora = _incubadoraRepository.GetById(id);
            return View(Incubadora);
        }
        public IActionResult Delete(int id)
        {
            _incubadoraRepository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Creating(IncubadoraModel incubadora)
        {

            if (ModelState.IsValid)
            {
                _incubadoraRepository.Creating(incubadora);
                return RedirectToAction("Index");
            }

            return View(incubadora);
            
        }

        [HttpPost]
        public IActionResult Update(IncubadoraModel incubadora)
        {
            if (ModelState.IsValid)
            {
                _incubadoraRepository.Update(incubadora);
                return RedirectToAction("Index");
            }

            return View(incubadora);
            
        }
    }
}
