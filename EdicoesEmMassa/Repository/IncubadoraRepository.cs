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
            _dbContext.incubadora.Add(incubadora);
            _dbContext.SaveChanges();
            return incubadora;
        }

        public bool Delete(int id)
        {
            IncubadoraModel incubadoradb = GetById(id);

            if (incubadoradb == null)
            {
                throw new System.Exception("Hou um erro na atualização da Incubadora");
            }

            _dbContext.incubadora.Remove(incubadoradb);
            _dbContext.SaveChanges();

            return true;
        }

        public List<IncubadoraModel> GetAll()
        {
            return _dbContext.incubadora.ToList();
        }

        public IncubadoraModel GetById(int id)
        {
            return _dbContext.incubadora.FirstOrDefault(x => x.id_incubadora == id);
        }

        public IncubadoraModel Update(IncubadoraModel incubadora)
        {
            IncubadoraModel incubadoradb = GetById(incubadora.id_incubadora);

            if (incubadoradb == null)
            {
                throw new System.Exception("Hou um erro na atualização da Incubadora");
            }

            incubadoradb.cod_incubadora = incubadora.cod_incubadora;
            incubadoradb.temperatura_fixada = incubadora.temperatura_fixada;

            _dbContext.incubadora.Update(incubadoradb);
            _dbContext.SaveChanges();

            return incubadoradb;
        }
    }
}
