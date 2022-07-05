using EdicoesEmMassa.Model;
using System.Collections.Generic;

namespace EdicoesEmMassa.Repository
{
    public interface ITemperaturaRepository
    {
        List<Temperatura> GetAll();
        Temperatura GetById(int id);
    }
}
