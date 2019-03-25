using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalcIR.Repository.Migrations
{
    public partial class v004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                schema: "ir",
                table: "Usuario",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "ir",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdExterno",
                schema: "ir",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                schema: "ir",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mercado",
                schema: "ir",
                table: "ResultadoAcumulado",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mercado",
                schema: "ir",
                table: "Papel",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ParametroUsuario",
                schema: "ir",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(nullable: true),
                    ValorLogico = table.Column<bool>(nullable: true),
                    ValorTexto = table.Column<string>(nullable: true),
                    ValorData = table.Column<DateTime>(nullable: true),
                    ValorNumerico = table.Column<decimal>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametroUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParametroUsuario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "ir",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParametroUsuario_UsuarioId",
                schema: "ir",
                table: "ParametroUsuario",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParametroUsuario",
                schema: "ir");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                schema: "ir",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "ir",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "IdExterno",
                schema: "ir",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Nome",
                schema: "ir",
                table: "Usuario");

            migrationBuilder.AlterColumn<string>(
                name: "Mercado",
                schema: "ir",
                table: "ResultadoAcumulado",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Mercado",
                schema: "ir",
                table: "Papel",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
