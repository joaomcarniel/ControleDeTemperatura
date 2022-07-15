using EdicoesEmMassa.Model;
using EdicoesEmMassa.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;

namespace EdicoesEmMassa.Controllers
{
    public class DashboardController : Controller
    {

        private readonly IIncubadoraRepository _IncubadoraRepository;
        private readonly ITemperaturaRepository _TemperaturaRepository;


        public DashboardController(IIncubadoraRepository IncubadoraRepository, ITemperaturaRepository TemperaturaRepository)
        {
            _IncubadoraRepository = IncubadoraRepository;
            _TemperaturaRepository = TemperaturaRepository;
        }

        public IActionResult Index()
        {
            List<IncubadoraTemperatura> _ITModel = new List<IncubadoraTemperatura>();
            Incubadora incubModel = new Incubadora();
            Temperatura tempModel = new Temperatura();
            var Temperaturas = _TemperaturaRepository.GetLastTemperatura();
            var Incubadoras = _IncubadoraRepository.GetAll();

            foreach (var Temperatura in Temperaturas)
            {
                foreach (var Incubadora in Incubadoras)
                {
                    if (Incubadora.id_incubadora == Temperatura.id_incubadora)
                    {
                        IncubadoraTemperatura itModel = new IncubadoraTemperatura()
                        {
                            Temperatura = Temperatura,
                            Incubadora = Incubadora
                        };
                        _ITModel.Add(itModel);
                    }
                }
            }
            return View(_ITModel);
        }
    }
}
