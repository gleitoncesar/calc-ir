using CalcIR.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalcIR.Repository
{
    public class CalcIRContext : DbContext
    {
        public CalcIRContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Custodia> Custodia { get; set; }
        public DbSet<NotaCorretagem> NotaCorretagem { get; set; }
        public DbSet<Operacao> Operacao { get; set; }
        public DbSet<Papel> Papel { get; set; }
        public DbSet<Resultado> Resultado { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForSqlServerUseIdentityColumns();
            modelBuilder.HasDefaultSchema("ir");

            ConfigurarCustodia(modelBuilder);
            ConfigurarNotaCorretagem(modelBuilder);
            ConfigurarOperacao(modelBuilder);
            ConfigurarPapel(modelBuilder);
            ConfigurarResultado(modelBuilder);
        }

        private void ConfigurarCustodia(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Custodia>(entry =>
            {
                entry.ToTable("Custodia");
                entry.HasKey(p=>p.Id).HasName("PK_Custodia");
                entry.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            });
        }

        private void ConfigurarNotaCorretagem(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NotaCorretagem>(entry =>
            {
                entry.ToTable("NotaCorretagem");
                entry.HasKey(p => p.Id).HasName("PK_NotaCorretagem");
                entry.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            });
        }

        private void ConfigurarOperacao(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operacao>(entry =>
            {
                entry.ToTable("Operacao");
                entry.HasKey(p => p.Id).HasName("PK_Operacao");
                entry.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            });
        }

        private void ConfigurarPapel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Papel>(entry =>
            {
                entry.ToTable("Papel");

                entry.HasKey(p => p.Id)
                .HasName("PK_Papel");

                entry.Property(p => p.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

                entry.Property(p => p.Codigo)
                .HasColumnName("Codigo")
                .HasColumnType("VARCHAR(12)");

                entry.Property(p => p.Mercado)
                .HasColumnName("Mercado")
                .HasColumnType("CHAR(1)");

                entry.Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasColumnType("VARCHAR(50)");
            });
        }

        private void ConfigurarResultado(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resultado>(entry =>
            {
                entry.ToTable("Resultado");
                entry.HasKey(p => p.Id).HasName("PK_Resultado");
                entry.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            });
        }
    }
}
