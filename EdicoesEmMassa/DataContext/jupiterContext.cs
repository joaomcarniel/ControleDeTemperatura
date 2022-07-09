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

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Incubadora> Incubadoras { get; set; }
        public virtual DbSet<Temperatura> Temperaturas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=jupiter;uid=root;pwd=root", ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PRIMARY");

                entity.ToTable("user");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserPass)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("user_pass");
            });

            modelBuilder.Entity<Incubadora>(entity =>
            {
                entity.HasKey(e => e.id_incubadora)
                    .HasName("PRIMARY");

                entity.ToTable("Incubadora");

                entity.Property(e => e.id_incubadora)
                    .ValueGeneratedNever()
                    .HasColumnName("id_incubadora");

                entity.Property(e => e.cod_incubadora)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("cod_incubadora");

                entity.Property(e => e.temperatura_fixada).HasColumnName("temperatura_fixada");
            });

            modelBuilder.Entity<Temperatura>(entity =>
            {
                entity.HasKey(e => e.id_temperatura)
                    .HasName("PRIMARY");

                entity.ToTable("Temperatura");

                entity.HasIndex(e => e.id_incubadora, "FK_Temperatura_Incubadora_Incubadoraid_incubadora_idx");

                entity.Property(e => e.id_temperatura)
                    .ValueGeneratedNever()
                    .HasColumnName("id_temperatura");

                entity.Property(e => e.id_incubadora).HasColumnName("id_incubadora");

                entity.Property(e => e.temperatura_atual).HasColumnName("temperatura_atual");

                /*entity.HasOne(d => d.id_incubadoraNavigation)
                    .WithMany(p => p.Temperaturas)
                    .HasForeignKey(d => d.id_incubadora)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Temperatura_Incubadora_Incubadoraid_incubadora");*/
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
