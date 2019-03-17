﻿// <auto-generated />
using System;
using CalcIR.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CalcIR.Repository.Migrations
{
    [DbContext(typeof(CalcIRContext))]
    [Migration("20190316215403_v002")]
    partial class v002
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("ir")
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CalcIR.Domain.Custodia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo");

                    b.Property<DateTime>("DataReferencia");

                    b.Property<int?>("PapelId");

                    b.Property<int>("Quantidade");

                    b.Property<int?>("UsuarioId");

                    b.Property<decimal>("Valor");

                    b.HasKey("Id")
                        .HasName("PK_Custodia");

                    b.HasIndex("PapelId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Custodia");
                });

            modelBuilder.Entity("CalcIR.Domain.NotaCorretagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataLiquidacao");

                    b.Property<DateTime>("DataPregao");

                    b.Property<int>("Numero");

                    b.Property<decimal>("TaxaLiquidacao");

                    b.Property<decimal>("TaxaRegistro");

                    b.Property<decimal>("TotalBovespa");

                    b.Property<decimal>("TotalCorretagem");

                    b.Property<int?>("UsuarioId");

                    b.Property<decimal>("Valorliquido");

                    b.HasKey("Id")
                        .HasName("PK_NotaCorretagem");

                    b.HasIndex("UsuarioId");

                    b.ToTable("NotaCorretagem");
                });

            modelBuilder.Entity("CalcIR.Domain.Operacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("DayTrade");

                    b.Property<int?>("NotaCorretagemId");

                    b.Property<int?>("PapelId");

                    b.Property<decimal>("Preco");

                    b.Property<int>("Quantidade");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<decimal>("ValorOperacao");

                    b.HasKey("Id")
                        .HasName("PK_Operacao");

                    b.HasIndex("NotaCorretagemId");

                    b.HasIndex("PapelId");

                    b.ToTable("Operacao");
                });

            modelBuilder.Entity("CalcIR.Domain.Papel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo");

                    b.Property<string>("Mercado");

                    b.Property<string>("Nome");

                    b.HasKey("Id")
                        .HasName("PK_Papel");

                    b.ToTable("Papel");
                });

            modelBuilder.Entity("CalcIR.Domain.ResultadoAcumulado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataResultado");

                    b.Property<string>("Mercado");

                    b.Property<decimal>("Valor");

                    b.HasKey("Id")
                        .HasName("PK_ResultadoAcumulado");

                    b.ToTable("ResultadoAcumulado");
                });

            modelBuilder.Entity("CalcIR.Domain.ResultadoOperacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataResultado");

                    b.Property<int?>("PapelId");

                    b.Property<int?>("UsuarioId");

                    b.Property<decimal>("Valor");

                    b.HasKey("Id")
                        .HasName("PK_ResultadoOperacao");

                    b.HasIndex("PapelId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("ResultadoOperacao");
                });

            modelBuilder.Entity("CalcIR.Domain.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apelido");

                    b.HasKey("Id")
                        .HasName("PK_Usuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("CalcIR.Domain.Custodia", b =>
                {
                    b.HasOne("CalcIR.Domain.Papel", "Papel")
                        .WithMany()
                        .HasForeignKey("PapelId");

                    b.HasOne("CalcIR.Domain.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("CalcIR.Domain.NotaCorretagem", b =>
                {
                    b.HasOne("CalcIR.Domain.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("CalcIR.Domain.Operacao", b =>
                {
                    b.HasOne("CalcIR.Domain.NotaCorretagem")
                        .WithMany("ListaOperacao")
                        .HasForeignKey("NotaCorretagemId");

                    b.HasOne("CalcIR.Domain.Papel", "Papel")
                        .WithMany()
                        .HasForeignKey("PapelId");
                });

            modelBuilder.Entity("CalcIR.Domain.ResultadoOperacao", b =>
                {
                    b.HasOne("CalcIR.Domain.Papel", "Papel")
                        .WithMany()
                        .HasForeignKey("PapelId");

                    b.HasOne("CalcIR.Domain.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");
                });
#pragma warning restore 612, 618
        }
    }
}
