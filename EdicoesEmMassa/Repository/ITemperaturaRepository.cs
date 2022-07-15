using EdicoesEmMassa.Model;
using System.Collections.Generic;

namespace EdicoesEmMassa.Repository
{
    public interface ITemperaturaRepository
    {
        List<Temperatura> GetLastTemperatura();
        Temperatura GetById(int id);
        List<Temperatura> GetAll();
    }
}
