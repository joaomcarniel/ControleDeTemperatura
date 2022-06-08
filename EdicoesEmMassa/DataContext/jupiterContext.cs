using System;
using EdicoesEmMassa.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EdicoesEmMassa.DataContext
{
    public partial class jupiterContext : DbContext
    {
        public jupiterContext()
        {
        }

        public jupiterContext(DbContextOptions<jupiterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Incubadora> Incubadoras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=127.0.0.1;database=jupiter;uid=root");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Incubadora>(entity =>
            {
                entity.HasKey(e => e.IdIncubadora)
                    .HasName("PRIMARY");

                entity.ToTable("incubadora");

                entity.Property(e => e.IdIncubadora)
                    .HasColumnType("int(11)")
                    .HasColumnName("idIncubadora");

                entity.Property(e => e.CodIncubadora)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("codIncubadora")
                    .HasDefaultValueSql("''''''")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.TemperaturaFixada).HasColumnName("temperaturaFixada");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
