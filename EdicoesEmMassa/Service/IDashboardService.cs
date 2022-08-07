using EdicoesEmMassa.Model;
using System.Collections.Generic;

namespace EdicoesEmMassa.Service
{
    public interface IDashboardService
    {
        public List<IncubadoraTemperatura> GetDataForDashboard();
    }
}
