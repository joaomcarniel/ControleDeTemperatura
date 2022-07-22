using EdicoesEmMassa.Model;
using EdicoesEmMassa.Model.Reports;
using System.Collections.Generic;

namespace EdicoesEmMassa.Repository
{
    public interface ITemperaturaRepository
    {
        List<Temperatura> GetLastTemperatura();
        Temperatura GetById(int id);
        List<Temperatura> GetAll();
        List<TemperatureReportModel> GetTemperatureReport();
    }
}
