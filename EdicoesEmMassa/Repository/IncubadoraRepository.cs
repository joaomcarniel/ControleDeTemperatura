using EdicoesEmMassa.DataContext;
using EdicoesEmMassa.Entity;
using EdicoesEmMassa.Model;
using Microsoft.EntityFrameworkCore;
using System;
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

        public Incubadora CreateById(InputTemperaturaByID input)
        {
            Incubadora incubadoradb = GetById(input.Id);

            if (incubadoradb == null)
            {
                throw new System.Exception("Houve um erro na atualização da Incubadora");
            }
            incubadoradb.TemperaturaAtual = input.TemperaturaAtual;

            incubadoradb.Historicos.Add(new TemperaturaHistorico()
            {
                DataCriacao = DateTime.UtcNow.AddHours(-3),
                TemperaturaAtual = input.TemperaturaAtual,
            });
            _dbContext.SaveChanges();
            return incubadoradb;
        }

        public Incubadora CreateByName(InputTemperaturaByName input)
        {
            Incubadora incubadoradb = _dbContext.Incubadora.FirstOrDefault(x => x.Name == input.Name);

            if (incubadoradb == null)
            {
                incubadoradb = new Incubadora()
                {
                    DataCriacao = DateTime.UtcNow.AddHours(-3),
                    Name = input.Name,
                    TemperaturaIdeal = Configuracoes.TemperaturaIdealPadrao
                };
            }

            incubadoradb.Historicos.Add(new TemperaturaHistorico()
            {
                DataCriacao = DateTime.UtcNow.AddHours(-3),
                TemperaturaAtual = input.TemperaturaAtual,
            });

            incubadoradb.TemperaturaAtual = input.TemperaturaAtual;
            _dbContext.SaveChanges();
            return incubadoradb;
        }

        public bool Delete(int id)
        {
            Incubadora incubadoradb = GetById(id);

            if (incubadoradb == null)
            {
                throw new System.Exception("Houve um erro na atualização da Incubadora");
            }

            _dbContext.Incubadora.Remove(incubadoradb);
            _dbContext.SaveChanges();

            return true;
        }

        public List<Incubadora> GetAll()
        {
            return _dbContext.Incubadora.ToList();
        }

        public Incubadora GetById(int id)
        {
            return _dbContext.Incubadora.FirstOrDefault(x => x.Id == id);
        }

        public Incubadora Update(Incubadora incubadora)
        {
            Incubadora incubadoradb = GetById(incubadora.Id);

            if (incubadoradb == null)
            {
                throw new System.Exception("Houve um erro na atualização da Incubadora");
            }

            _dbContext.Incubadora.Attach(incubadora);
            _dbContext.Entry(incubadora).State = EntityState.Modified;

            _dbContext.Incubadora.Update(incubadoradb);
            _dbContext.SaveChanges();

            return incubadoradb;
        }
    }
}
