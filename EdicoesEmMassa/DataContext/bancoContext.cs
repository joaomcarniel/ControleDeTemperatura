using EdicoesEmMassa.Entity;
using Microsoft.EntityFrameworkCore;

namespace EdicoesEmMassa.DataContext
{
    //dotnet ef migrations add CriacaoInicial -o Migrations --project EdicoesEmMassa
    public class bancoContext : DbContext
    {
        public bancoContext(DbContextOptions<bancoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Incubadora> Incubadora { get; set; }
        public DbSet<TemperaturaHistorico> TemperaturaHistorico { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Incubadora>()
                .HasMany(x => x.Historicos)
                .WithOne(x => x.Incubadora)
                .HasForeignKey(x => x.IdIncubadora);

            modelBuilder.Entity<TemperaturaHistorico>()
                .HasIndex(x => x.IdIncubadora);
        }

    }
}
