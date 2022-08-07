using EdicoesEmMassa.Repository;
using EdicoesEmMassa.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EdicoesEmMassa.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly IRelatorioService _TemperaturaRepository;


        public RelatorioController(IRelatorioService temperaturaRepository)
        {
            _TemperaturaRepository = temperaturaRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreatePDF()
        {
            _TemperaturaRepository.DeserializeTemperatura();
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
