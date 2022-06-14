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
        public DbSet<TemperaturaModel> Temperatura { get; set; }
        public DbSet<Abacate> Abacate { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Abacate>().HasNoKey();
        }

    }
}
