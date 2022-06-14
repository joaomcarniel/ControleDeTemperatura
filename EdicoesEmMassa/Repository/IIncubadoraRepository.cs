using EdicoesEmMassa.Entity;
using EdicoesEmMassa.Model;
using System.Collections.Generic;

namespace EdicoesEmMassa.Repository
{
    public interface IIncubadoraRepository
    {
        Incubadora CreateByName(InputTemperaturaByName input);
        Incubadora CreateById(InputTemperaturaByID input);
        List<Incubadora> GetAll();
        Incubadora GetById(int id);
        Incubadora Update(Incubadora incubadora);
        bool Delete(int id);
    }
}
