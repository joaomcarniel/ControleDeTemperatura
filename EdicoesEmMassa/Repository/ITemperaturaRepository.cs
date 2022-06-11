using EdicoesEmMassa.Model;
using System.Collections.Generic;

namespace EdicoesEmMassa.Repository
{
    public interface ITemperaturaRepository
    {
        List<TemperaturaModel> GetAll();
        TemperaturaModel GetById(int id);
    }
}
