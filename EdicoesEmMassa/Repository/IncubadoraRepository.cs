using EdicoesEmMassa.DataContext;
using EdicoesEmMassa.Model;

namespace EdicoesEmMassa.Repository
{
    public class IncubadoraRepository : InterIncubadoraRepository
    {
        private readonly jupiterContext _dbContext;
        public IncubadoraRepository(jupiterContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Incubadora Creating(Incubadora incubadora)
        {
            _dbContext.Incubadoras.Add(incubadora);
            _dbContext.SaveChanges();

            return incubadora;
        }

    }
}
