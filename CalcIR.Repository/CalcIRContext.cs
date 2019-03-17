using CalcIR.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public DbSet<ResultadoOperacao> ResultadoOperacao { get; set; }
        public DbSet<ResultadoAcumulado> ResultadoAcumulado { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForSqlServerUseIdentityColumns();
            modelBuilder.HasDefaultSchema("ir");

            ConfigurarCustodia(modelBuilder);
            ConfigurarNotaCorretagem(modelBuilder);
            ConfigurarOperacao(modelBuilder);
            ConfigurarPapel(modelBuilder);
            ConfigurarResultadoAcumulado(modelBuilder);
            ConfigurarResultadoOperacao(modelBuilder);
            ConfigurarUsuario(modelBuilder);
        }

        public void TrySaveChanges()
        {
            try
            {
                SaveChanges();
            }
            catch (Exception ex)
            {
                //TODO Log
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }

        private void ConfigurarCustodia(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Custodia>(entry =>
            {
                entry.ToTable("Custodia");
                entry.HasKey(p => p.Id).HasName("PK_Custodia");
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
            });
        }

        private void ConfigurarUsuario(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entry =>
            {
                entry.ToTable("Usuario");
                entry.HasKey(p => p.Id).HasName("PK_Usuario");
                entry.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            });
        }

        private void ConfigurarResultadoOperacao(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResultadoOperacao>(entry =>
            {
                entry.ToTable("ResultadoOperacao");
                entry.HasKey(p => p.Id).HasName("PK_ResultadoOperacao");
                entry.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            });
        }

        private void ConfigurarResultadoAcumulado(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResultadoAcumulado>(entry =>
            {
                entry.ToTable("ResultadoAcumulado");
                entry.HasKey(p => p.Id).HasName("PK_ResultadoAcumulado");
                entry.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            });
        }
    }
}
