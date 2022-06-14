using EdicoesEmMassa.DataContext;
using EdicoesEmMassa.Entity;
using System.Collections.Generic;
using System.Linq;

namespace EdicoesEmMassa.Repository
{
    public class TemperaturaRepository : ITemperaturaRepository
    {
        private readonly bancoContext _dbContext;
        public TemperaturaRepository(bancoContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<TemperaturaHistorico> GetAll()
        {
            return _dbContext.TemperaturaHistorico.ToList();
        }
        public TemperaturaHistorico GetById(int id)
        {
            return _dbContext.TemperaturaHistorico.FirstOrDefault(x => x.Id == id);
        }
    }
}
