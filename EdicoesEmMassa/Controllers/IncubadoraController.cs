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
        public IActionResult Creating(IncubadoraModel incubadora)
        {
            _incubadoraRepository.Creating(incubadora);
            return RedirectToAction("Index");
        }
    }
}
