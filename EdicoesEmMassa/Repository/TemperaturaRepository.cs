using EdicoesEmMassa.DataContext;
using EdicoesEmMassa.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EdicoesEmMassa.Repository
{
    public class TemperaturaRepository : ITemperaturaRepository
    {
        private readonly jupiterContext _dbContext;
        public TemperaturaRepository(jupiterContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Temperatura> GetLastTemperatura()
        {
            return _dbContext.Temperaturas.FromSqlRaw(@"SELECT id_temperatura, temperatura_atual, id_incubadora
                FROM temperatura JOIN (SELECT MAX(id_temperatura) as ""ultimoId""
                FROM temperatura GROUP BY id_incubadora) as sub
                ON sub.ultimoId = temperatura.id_temperatura").ToList();
        }
        public Temperatura GetById(int id)
        {
            return _dbContext.Temperaturas.FirstOrDefault(x => x.id_temperatura == id);
        }

        public List<Temperatura> GetAll()
        {
            return _dbContext.Temperaturas.ToList();
        }
    }
}
