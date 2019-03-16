using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalcIR.Repository.Migrations
{
    public partial class v001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ir");

            migrationBuilder.CreateTable(
                name: "Papel",
                schema: "ir",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(type: "VARCHAR(12)", nullable: true),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Mercado = table.Column<string>(type: "CHAR(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Papel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResultadoAcumulado",
                schema: "ir",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataResultado = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultadoAcumulado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "ir",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Apelido = table.Column<string>(type: "VARCHAR(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Custodia",
                schema: "ir",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataReferencia = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: true),
                    PapelId = table.Column<int>(nullable: true),
                    Quantidade = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Custodia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Custodia_Papel_PapelId",
                        column: x => x.PapelId,
                        principalSchema: "ir",
                        principalTable: "Papel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Custodia_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "ir",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotaCorretagem",
                schema: "ir",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    DataPregao = table.Column<DateTime>(nullable: false),
                    DataLiquidacao = table.Column<DateTime>(nullable: false),
                    TaxaLiquidacao = table.Column<decimal>(nullable: false),
                    TaxaRegistro = table.Column<decimal>(nullable: false),
                    TotalBovespa = table.Column<decimal>(nullable: false),
                    TotalCorretagem = table.Column<decimal>(nullable: false),
                    Valorliquido = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaCorretagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotaCorretagem_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "ir",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResultadoOperacao",
                schema: "ir",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: true),
                    PapelId = table.Column<int>(nullable: true),
                    DataResultado = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultadoOperacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultadoOperacao_Papel_PapelId",
                        column: x => x.PapelId,
                        principalSchema: "ir",
                        principalTable: "Papel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResultadoOperacao_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "ir",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Operacao",
                schema: "ir",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PapelId = table.Column<int>(nullable: true),
                    DayTrade = table.Column<bool>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    Preco = table.Column<decimal>(nullable: false),
                    ValorOperacao = table.Column<decimal>(nullable: false),
                    Tipo = table.Column<string>(type: "CHAR(1)", nullable: false),
                    NotaCorretagemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operacao_NotaCorretagem_NotaCorretagemId",
                        column: x => x.NotaCorretagemId,
                        principalSchema: "ir",
                        principalTable: "NotaCorretagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operacao_Papel_PapelId",
                        column: x => x.PapelId,
                        principalSchema: "ir",
                        principalTable: "Papel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Custodia_PapelId",
                schema: "ir",
                table: "Custodia",
                column: "PapelId");

            migrationBuilder.CreateIndex(
                name: "IX_Custodia_UsuarioId",
                schema: "ir",
                table: "Custodia",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaCorretagem_UsuarioId",
                schema: "ir",
                table: "NotaCorretagem",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Operacao_NotaCorretagemId",
                schema: "ir",
                table: "Operacao",
                column: "NotaCorretagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Operacao_PapelId",
                schema: "ir",
                table: "Operacao",
                column: "PapelId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultadoOperacao_PapelId",
                schema: "ir",
                table: "ResultadoOperacao",
                column: "PapelId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultadoOperacao_UsuarioId",
                schema: "ir",
                table: "ResultadoOperacao",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Custodia",
                schema: "ir");

            migrationBuilder.DropTable(
                name: "Operacao",
                schema: "ir");

            migrationBuilder.DropTable(
                name: "ResultadoAcumulado",
                schema: "ir");

            migrationBuilder.DropTable(
                name: "ResultadoOperacao",
                schema: "ir");

            migrationBuilder.DropTable(
                name: "NotaCorretagem",
                schema: "ir");

            migrationBuilder.DropTable(
                name: "Papel",
                schema: "ir");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "ir");
        }
    }
}
