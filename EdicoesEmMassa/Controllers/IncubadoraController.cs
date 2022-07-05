using EdicoesEmMassa.Model;
using EdicoesEmMassa.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EdicoesEmMassa.Controllers
{
    public class IncubadoraController : Controller
    {
        private readonly IIncubadoraRepository _IncubadoraRepository;

        public IncubadoraController(IIncubadoraRepository IncubadoraRepository)
        {
            _IncubadoraRepository = IncubadoraRepository;
        }
        public IActionResult Index()
        {
            var Incubadoras = _IncubadoraRepository.GetAll();
            return View(Incubadoras);
        }

        public IActionResult Creating()
        {
            return View();
        }

        public IActionResult Update(int id)
        {
            var Incubadora = _IncubadoraRepository.GetById(id);
            return View(Incubadora);
        }

        public IActionResult ConfirmDelete(int id)
        {
            var Incubadora = _IncubadoraRepository.GetById(id);
            return View(Incubadora);
        }
        public IActionResult Delete(int id)
        {
            _IncubadoraRepository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Creating(Incubadora Incubadora)
        {

            if (ModelState.IsValid)
            {
                _IncubadoraRepository.Creating(Incubadora);
                return RedirectToAction("Index");
            }

            return View(Incubadora);

        }

        [HttpPost]
        public IActionResult Update(Incubadora Incubadora)
        {
            if (ModelState.IsValid)
            {
                _IncubadoraRepository.Update(Incubadora);
                return RedirectToAction("Index");
            }

            return View(Incubadora);

        }
    }
}
