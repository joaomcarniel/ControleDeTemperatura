using EdicoesEmMassa.Repository;
using System;

namespace EdicoesEmMassa.Services
{
   
    public class DashboardService
    {
        private readonly ITemperaturaRepository _temperaturaRepository;

        DashboardService(ITemperaturaRepository temperaturaRepository)
        {
            _temperaturaRepository = temperaturaRepository;
        }

        internal void GetUpdate()
        {
            var _temperaturaRepository.GetAll();
        }
    }
}
