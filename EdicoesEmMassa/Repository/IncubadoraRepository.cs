using EdicoesEmMassa.DataContext;
using EdicoesEmMassa.Model;
using System.Collections.Generic;
using System.Linq;

namespace EdicoesEmMassa.Repository
{
    public class IncubadoraRepository : IIncubadoraRepository
    {
        private readonly jupiterContext _dbContext;
        public IncubadoraRepository(jupiterContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Incubadora Creating(Incubadora Incubadora)
        {
            _dbContext.Incubadoras.Add(Incubadora);
            _dbContext.SaveChanges();
            return Incubadora;
        }

        public bool Delete(int id)
        {
            Incubadora Incubadoradb = GetById(id);

            if (Incubadoradb == null)
            {
                throw new System.Exception("Hou um erro na atualização da Incubadora");
            }

            _dbContext.Incubadoras.Remove(Incubadoradb);
            _dbContext.SaveChanges();

            return true;
        }

        public List<Incubadora> GetAll()
        {
            var teste = _dbContext.Incubadoras.ToList();
            return teste;
        }

        public Incubadora GetById(int id)
        {
            return _dbContext.Incubadoras.FirstOrDefault(x => x.id_incubadora == id);
        }

        public Incubadora Update(Incubadora Incubadora)
        {
            Incubadora Incubadoradb = GetById(Incubadora.id_incubadora);

            if (Incubadoradb == null)
            {
                throw new System.Exception("Hou um erro na atualização da Incubadora");
            }

            Incubadoradb.cod_incubadora = Incubadora.cod_incubadora;
            Incubadoradb.temperatura_fixada = Incubadora.temperatura_fixada;

            _dbContext.Incubadoras.Update(Incubadoradb);
            _dbContext.SaveChanges();

            return Incubadoradb;
        }
    }
}
