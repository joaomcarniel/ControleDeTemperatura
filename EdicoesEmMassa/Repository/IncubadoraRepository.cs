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

        public bool Delete(int id)
        {
            IncubadoraModel incubadoradb = GetById(id);

            if (incubadoradb == null)
            {
                throw new System.Exception("Hou um erro na atualização da Incubadora");
            }

            _dbContext.Incubadora.Remove(incubadoradb);
            _dbContext.SaveChanges();

            return true;
        }

        public List<IncubadoraModel> GetAll()
        {
            return _dbContext.Incubadora.ToList();
        }

        public IncubadoraModel GetById(int id)
        {
            return _dbContext.Incubadora.FirstOrDefault(x => x.IdIncubadora == id);
        }

        public IncubadoraModel Update(IncubadoraModel incubadora)
        {
            IncubadoraModel incubadoradb = GetById(incubadora.IdIncubadora);

            if (incubadoradb == null)
            {
                throw new System.Exception("Hou um erro na atualização da Incubadora");
            }

            incubadoradb.CodIncubadora = incubadora.CodIncubadora;
            incubadoradb.TemperaturaFixada = incubadora.TemperaturaFixada;

            _dbContext.Incubadora.Update(incubadoradb);
            _dbContext.SaveChanges();

            return incubadoradb;
        }
    }
}
