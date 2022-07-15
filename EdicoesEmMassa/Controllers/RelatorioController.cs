using EdicoesEmMassa.Repository;
using EdicoesEmMassa.Service;
using Microsoft.AspNetCore.Mvc;

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

        public void CreatePDF()
        {
            _TemperaturaRepository.DeserializeTemperatura();
        }
    }
}
