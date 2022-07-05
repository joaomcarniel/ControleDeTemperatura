using EdicoesEmMassa.Model;
using System.Collections.Generic;

namespace EdicoesEmMassa.Repository
{
    public interface IIncubadoraRepository
    {
        Incubadora Creating(Incubadora Incubadora);
        List<Incubadora> GetAll();
        Incubadora GetById(int id);
        Incubadora Update(Incubadora Incubadora);
        bool Delete(int id);
    }
}
