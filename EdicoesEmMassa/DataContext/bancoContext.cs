using EdicoesEmMassa.Model;
using Microsoft.EntityFrameworkCore;

namespace EdicoesEmMassa.DataContext
{
    public class bancoContext : DbContext
    {
        public bancoContext(DbContextOptions<bancoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<IncubadoraModel> incubadora { get; set; }
        public DbSet<TemperaturaModel> temperatura { get; set; }
        //public DbSet<Abacate> Abacate { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Abacate>().HasNoKey();
        }

    }
}
