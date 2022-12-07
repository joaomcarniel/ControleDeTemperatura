using EdicoesEmMassa.Model;
using EdicoesEmMassa.Repository;
using EdicoesEmMassa.Service;
using Microsoft.AspNetCore.Mvc;

namespace EdicoesEmMassa.Controllers
{
    public class IncubadoraController : Controller
    {
        private readonly IIncubatorService _incubatorService;

        public IncubadoraController(IIncubatorService incubatorService)
        {
            _incubatorService = incubatorService;
        }
        public IActionResult Index()
        {
            var Incubadoras = _incubatorService.GetAll();
            return View(Incubadoras);
        }

        public IActionResult Creating()
        {
            return View();
        }

        public IActionResult Update(int id)
        {
            var Incubadora = _incubatorService.GetById(id);
            return View(Incubadora);
        }

        public IActionResult ConfirmDelete(int id)
        {
            var Incubadora = _incubatorService.GetById(id);
            return View(Incubadora);
        }
        public IActionResult Delete(int id)
        {

            _incubatorService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Creating(Incubadora Incubadora)
        {

            if (ModelState.IsValid)
            {
                _incubatorService.Creating(Incubadora);
                return RedirectToAction("Index");
            }

            return View(Incubadora);

        }

        [HttpPost]
        public IActionResult Update(Incubadora Incubadora)
        {
            if (ModelState.IsValid)
            {
                _incubatorService.Update(Incubadora);
                return RedirectToAction("Index");
            }

            return View(Incubadora);
        }
    }
}
