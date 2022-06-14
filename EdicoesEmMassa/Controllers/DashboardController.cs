using EdicoesEmMassa.Model;
using EdicoesEmMassa.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            var temperaturas = _temperaturaRepository.GetAll();
            var incubadoras = _incubadoraRepository.GetAll();

            foreach(var temperatura in temperaturas)
            {
                foreach (var incubadora in incubadoras)
                {
                    if(incubadora.IdIncubadora == temperatura.Incubadora.IdIncubadora)
                    {
                        IncubadoraTemperaturaModel itModel = new IncubadoraTemperaturaModel()
                        {
                            Temperatura = temperatura,
                            Incubadora = incubadora
                        };
                        _ITModel.Add(itModel);   
                    }
                }
            }
            return View(_ITModel);
        }
    }
}
