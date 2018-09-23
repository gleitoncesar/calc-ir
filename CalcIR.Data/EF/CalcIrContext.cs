using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CalcIR.Data
{
    public partial class CalcIrContext : DbContext
    {
        public CalcIrContext()
        {
        }

        public CalcIrContext(DbContextOptions<CalcIrContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Corretora> Corretora { get; set; }
        public virtual DbSet<Mercado> Mercado { get; set; }
        public virtual DbSet<Negocio> Negocio { get; set; }
        public virtual DbSet<Nota> Nota { get; set; }
        public virtual DbSet<Operacao> Operacao { get; set; }
        public virtual DbSet<Papel> Papel { get; set; }
        public virtual DbSet<TipoNegocio> TipoNegocio { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioCorretora> UsuarioCorretora { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=calc-ir;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Corretora>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Mercado>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Negocio>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PrecoAjustado).HasColumnType("money");

                entity.HasOne(d => d.IdMercadoNavigation)
                    .WithMany(p => p.Negocio)
                    .HasForeignKey(d => d.IdMercado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Negocio_02");

                entity.HasOne(d => d.IdNotaNavigation)
                    .WithMany(p => p.Negocio)
                    .HasForeignKey(d => d.IdNota)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Negocio_01");

                entity.HasOne(d => d.IdPapelNavigation)
                    .WithMany(p => p.Negocio)
                    .HasForeignKey(d => d.IdPapel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Negocio_04");

                entity.HasOne(d => d.IdTipoNegocioNavigation)
                    .WithMany(p => p.Negocio)
                    .HasForeignKey(d => d.IdTipoNegocio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Negocio_03");
            });

            modelBuilder.Entity<Nota>(entity =>
            {
                entity.Property(e => e.DataPregao).HasColumnType("date");

                entity.Property(e => e.ValorLiquido).HasColumnType("money");

                entity.HasOne(d => d.IdCorretoraNavigation)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.IdCorretora)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Nota_02");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Nota_01");
            });

            modelBuilder.Entity<Operacao>(entity =>
            {
                entity.Property(e => e.DataFim).HasColumnType("date");

                entity.Property(e => e.DataInicio).HasColumnType("date");

                entity.Property(e => e.Resultado).HasColumnType("money");

                entity.Property(e => e.ValorMedio).HasColumnType("money");

                entity.HasOne(d => d.IdPapelNavigation)
                    .WithMany(p => p.Operacao)
                    .HasForeignKey(d => d.IdPapel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operacao_02");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Operacao)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operacao_01");
            });

            modelBuilder.Entity<Papel>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoNegocio>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsuarioCorretora>(entity =>
            {
                entity.HasOne(d => d.IdCorretoraNavigation)
                    .WithMany(p => p.UsuarioCorretora)
                    .HasForeignKey(d => d.IdCorretora)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioCorretora_02");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioCorretora)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioCorretora_01");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
