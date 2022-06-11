using EdicoesEmMassa.DataContext;
using EdicoesEmMassa.Model;
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
        public List<TemperaturaModel> GetAll()
        {
            return _dbContext.Temperatura.ToList();
        }
        public TemperaturaModel GetById(int id)
        {
            return _dbContext.Temperatura.FirstOrDefault(x => x.IdTemperatura == id);
        }
    }
}
