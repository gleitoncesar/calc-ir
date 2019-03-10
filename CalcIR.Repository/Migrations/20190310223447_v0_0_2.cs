using Microsoft.EntityFrameworkCore.Migrations;

namespace CalcIR.Repository.Migrations
{
    public partial class v0_0_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                schema: "ir",
                table: "Papel",
                type: "VARCHAR(12)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mercado",
                schema: "ir",
                table: "Papel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                schema: "ir",
                table: "Papel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                schema: "ir",
                table: "Papel");

            migrationBuilder.DropColumn(
                name: "Mercado",
                schema: "ir",
                table: "Papel");

            migrationBuilder.DropColumn(
                name: "Nome",
                schema: "ir",
                table: "Papel");
        }
    }
}
