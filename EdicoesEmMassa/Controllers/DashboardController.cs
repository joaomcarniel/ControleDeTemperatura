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
            List<IncubadoraTemperaturaModel> _ITModel;
            IncubadoraModel incubModel = new IncubadoraModel();
            TemperaturaModel tempModel = new TemperaturaModel();
            var temperaturas = _temperaturaRepository.GetAll();
            var incubadoras = _incubadoraRepository.GetAll();

            for(int i = 1; i < temperaturas.Count; i++)
            {
                foreach (var incubadora in incubadoras)
                {
                    if(incubadora.IdIncubadora == temperaturas[i].Incubadora.IdIncubadora)
                    {
                        incubModel.IdIncubadora = incubadora.IdIncubadora;
                        incubModel.CodIncubadora = incubadora.CodIncubadora;
                        incubModel.TemperaturaFixada = incubadora.TemperaturaFixada;

                        tempModel.IdTemperatura = temperaturas[i].IdTemperatura;
                        tempModel.TemperaturaAtual = temperaturas[i].TemperaturaAtual;
                        tempModel.Incubadora = temperaturas[i].Incubadora;

                        _ITModel.AddRange(incubModel, tempModel);
                        //_ITModel[i].Temperatura = tempModel;
                        //_ITModel.Temperatura = (List<TemperaturaModel>)tempModel;
                        //_ITModel.Incubadora.Add(incubModel);
                    }
                }
            }
            return View(_ITModel);
        }
    }
}
