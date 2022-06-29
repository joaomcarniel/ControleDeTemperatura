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
            return _dbContext.temperatura.FromSqlRaw(@"SELECT id_temperatura, temperatura_atual, id_incubadora
                FROM temperatura JOIN (SELECT MAX(id_temperatura) as ""ultimoId""
                 FROM temperatura GROUP BY id_incubadora) ""sub""
ON               sub.""ultimoId"" = temperatura.id_temperatura").ToList();
        }
        public TemperaturaModel GetById(int id)
        {
            return _dbContext.temperatura.FirstOrDefault(x => x.id_temperatura == id);
        }
    }
}
