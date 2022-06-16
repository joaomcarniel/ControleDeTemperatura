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
            return _dbContext.Temperatura.FromSqlRaw(@"
                        SELECT ""IdTemperatura"", ""TemperaturaAtual"", ""abacate"".""IncubadoraIdIncubadora"" 
                          FROM ""Temperatura""
                          JOIN ( SELECT MAX(""IdTemperatura"") as ""ultimoId"", ""IncubadoraIdIncubadora"" 
                                   FROM ""Temperatura""
                                  GROUP BY ""IncubadoraIdIncubadora"") ""abacate""
                            ON ""abacate"".""ultimoId"" = ""Temperatura"".""IdTemperatura""").ToList();
        }
        public TemperaturaModel GetById(int id)
        {
            return _dbContext.Temperatura.FirstOrDefault(x => x.IdTemperatura == id);
        }
    }
}
