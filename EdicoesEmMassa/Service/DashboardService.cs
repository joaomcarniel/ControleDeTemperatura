using EdicoesEmMassa.Model;
using EdicoesEmMassa.Repository;
using System.Collections.Generic;
using System.Linq;

namespace EdicoesEmMassa.Service
{
    public class DashboardService : IDashboardService
    {
        private readonly ITemperaturaRepository _temperaturaRepository;
        private readonly IIncubadoraRepository _incubadoraRepository;

        public DashboardService(ITemperaturaRepository temperaturaRepository, IIncubadoraRepository incubadoraRepository)
        {
            _temperaturaRepository = temperaturaRepository;
            _incubadoraRepository = incubadoraRepository;
        }

        public List<IncubadoraTemperatura> GetDataForDashboard()
        {
            Incubadora incubModel = new Incubadora();
            Temperatura tempModel = new Temperatura();
            var Temperaturas = _temperaturaRepository.GetLastTemperatura();
            var Incubadoras = _incubadoraRepository.GetAll();
            //var teste = Incubadoras.Where(x => x.id_incubadora == Temperaturas.FirstOrDefault().id_incubadora);
            return AssociateTemperatureWithIncubator(Temperaturas, Incubadoras);
        }

        public List<IncubadoraTemperatura> AssociateTemperatureWithIncubator(List<Temperatura> temperatures, List<Incubadora> incubators)
        {
            List<IncubadoraTemperatura> tempAndIncubator = new List<IncubadoraTemperatura>();
            foreach (var temperature in temperatures)
            {
                var incubator = (Incubadora)incubators.FirstOrDefault(x => x.id_incubadora == temperature.id_incubadora);
                if(incubator != null)
                {
                    IncubadoraTemperatura itModel = new IncubadoraTemperatura()
                    {
                        Temperatura = temperature,
                        Incubadora = incubator
                    };
                    tempAndIncubator.Add(itModel);
                }
            }
            return tempAndIncubator;
        }
    }
}
