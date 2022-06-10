using EdicoesEmMassa.Model;
using Microsoft.EntityFrameworkCore;

namespace EdicoesEmMassa.DataContext
{
    public class bancoContext : DbContext
    {
        public bancoContext(DbContextOptions<bancoContext> options) : base(options)
        {

        }

        public DbSet<IncubadoraModel> Incubadora { get; set; }

    }
}
