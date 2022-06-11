using EdicoesEmMassa.Repository;
using EdicoesEmMassa.Services;
using Microsoft.AspNetCore.Mvc;

namespace EdicoesEmMassa.Controllers
{
    public class DashboardController : Controller
    {
        
        private readonly DashboardService _dashService;

        public DashboardController(DashboardService dashService)
        {
            _dashService = dashService;
        }

        public IActionResult Index()
        {
            _dashService.GetUpdate();
            //var incubadoras = _incubadoraRepository.GetAll();
            //return View(incubadoras);
        }
    }
}
