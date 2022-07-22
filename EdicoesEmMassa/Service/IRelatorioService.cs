using EdicoesEmMassa.Model;
using EdicoesEmMassa.Model.Reports;
using System.Collections.Generic;

namespace EdicoesEmMassa.Service
{
    public interface IRelatorioService
    {
        public void DeserializeTemperatura();
        void CreatePDF(List<TemperatureReportModel> temperatureReport);
    }
}
