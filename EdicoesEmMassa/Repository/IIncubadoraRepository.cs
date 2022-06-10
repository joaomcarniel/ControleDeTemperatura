using EdicoesEmMassa.Model;
using System.Collections.Generic;

namespace EdicoesEmMassa.Repository
{
    public interface IIncubadoraRepository
    {
        IncubadoraModel Creating(IncubadoraModel incubadora);

        List<IncubadoraModel> GetAll();
    }
}
