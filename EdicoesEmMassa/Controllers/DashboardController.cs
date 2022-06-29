using EdicoesEmMassa.Model;
using EdicoesEmMassa.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;

namespace EdicoesEmMassa.Controllers
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
            List<IncubadoraTemperaturaModel> _ITModel = new List<IncubadoraTemperaturaModel>();
            IncubadoraModel incubModel = new IncubadoraModel();
            TemperaturaModel tempModel = new TemperaturaModel();
            while (true)
            {
                Thread.Sleep(50);
                var temperaturas = _temperaturaRepository.GetAll();
                var incubadoras = _incubadoraRepository.GetAll();

                foreach (var temperatura in temperaturas)
                {
                    foreach (var incubadora in incubadoras)
                    {
                        if (incubadora.id_incubadora == temperatura.id_incubadora)
                        {
                            IncubadoraTemperaturaModel itModel = new IncubadoraTemperaturaModel()
                            {
                                temperatura = temperatura,
                                incubadora = incubadora
                            };
                            _ITModel.Add(itModel);
                        }
                    }
                }
                return View(_ITModel);
            }
            
        }
    }
}
