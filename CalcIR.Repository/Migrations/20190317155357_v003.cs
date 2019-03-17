using Microsoft.EntityFrameworkCore.Migrations;

namespace CalcIR.Repository.Migrations
{
    public partial class v003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                schema: "ir",
                table: "ResultadoAcumulado",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResultadoAcumulado_UsuarioId",
                schema: "ir",
                table: "ResultadoAcumulado",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultadoAcumulado_Usuario_UsuarioId",
                schema: "ir",
                table: "ResultadoAcumulado",
                column: "UsuarioId",
                principalSchema: "ir",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultadoAcumulado_Usuario_UsuarioId",
                schema: "ir",
                table: "ResultadoAcumulado");

            migrationBuilder.DropIndex(
                name: "IX_ResultadoAcumulado_UsuarioId",
                schema: "ir",
                table: "ResultadoAcumulado");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                schema: "ir",
                table: "ResultadoAcumulado");
        }
    }
}
