using EdicoesEmMassa.Entity;
using System.Collections.Generic;

namespace EdicoesEmMassa.Repository
{
    public interface ITemperaturaRepository
    {
        List<TemperaturaHistorico> GetAll();
        TemperaturaHistorico GetById(int id);
    }
}
