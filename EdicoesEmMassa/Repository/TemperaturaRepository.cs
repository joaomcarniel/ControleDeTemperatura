using EdicoesEmMassa.DataContext;
using EdicoesEmMassa.Model;
using Microsoft.EntityFrameworkCore;
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
            return _dbContext.Temperatura.FromSqlRaw(@"SELECT IdTemperatura,temperaturaAtual, abacate.IncubadoraIdIncubadora from temperatura
                        JOIN(
                        SELECT MAX(IdTemperatura) as ""ultimoId"", IncubadoraIdIncubadora from temperatura
                        GROUP BY IncubadoraIdIncubadora) ""abacate""
                        ON abacate.ultimoId = temperatura.IdTemperatura").ToList();
        }
        public TemperaturaModel GetById(int id)
        {
            return _dbContext.Temperatura.FirstOrDefault(x => x.IdTemperatura == id);
        }
    }
}
