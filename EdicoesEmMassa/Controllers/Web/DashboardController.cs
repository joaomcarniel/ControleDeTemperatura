using EdicoesEmMassa.Entity;
using EdicoesEmMassa.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EdicoesEmMassa.Controllers.Web
{
    public class DashboardController : Controller
    {

        private readonly IIncubadoraRepository _incubadoraRepository;
        private readonly ITemperaturaRepository _temperaturaRepository;


        public DashboardController(IIncubadoraRepository incubadoraRepository, ITemperaturaRepository temperaturaRepository)
        {
            _incubadoraRepository = incubadoraRepository;
            _temperaturaRepository = temperaturaRepository;
        }

        public IActionResult Index()
        {
            List<Incubadora> ResultModel = _incubadoraRepository.GetAll();
            return View(ResultModel);
        }
    }
}
