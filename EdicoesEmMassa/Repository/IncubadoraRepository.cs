using EdicoesEmMassa.DataContext;
using EdicoesEmMassa.Model;
using System.Collections.Generic;
using System.Linq;

namespace EdicoesEmMassa.Repository
{
    public class IncubadoraRepository : IIncubadoraRepository
    {
        private readonly bancoContext _dbContext;
        public IncubadoraRepository(bancoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IncubadoraModel Creating(IncubadoraModel incubadora)
        {
            _dbContext.Incubadora.Add(incubadora);
            _dbContext.SaveChanges();
            return incubadora;
        }

        public List<IncubadoraModel> GetAll()
        {
            return _dbContext.Incubadora.ToList();
        }
    }
}
