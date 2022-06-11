using EdicoesEmMassa.Model;
using System.Collections.Generic;

namespace EdicoesEmMassa.Repository
{
    public interface IIncubadoraRepository
    {
        IncubadoraModel Creating(IncubadoraModel incubadora);
        List<IncubadoraModel> GetAll();
        IncubadoraModel GetById(int id);
        IncubadoraModel Update(IncubadoraModel incubadora);
        bool Delete(int id);
    }
}
