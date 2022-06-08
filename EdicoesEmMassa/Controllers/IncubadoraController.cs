using EdicoesEmMassa.Model;
using EdicoesEmMassa.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EdicoesEmMassa.Controllers
{
    public class IncubadoraController : Controller
    {
        private readonly InterIncubadoraRepository _incubadoraRepository;

        public IncubadoraController(InterIncubadoraRepository incubadoraRepository)
        {
            _incubadoraRepository = incubadoraRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult ConfirmDelete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Creating(Incubadora incubadora)
        {
            _incubadoraRepository.Creating(incubadora);
            return RedirectToAction("Index");
        }
    }
}
