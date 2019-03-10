using Microsoft.EntityFrameworkCore.Migrations;

namespace CalcIR.Repository.Migrations
{
    public partial class v0_0_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                schema: "ir",
                table: "Papel",
                type: "VARCHAR(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mercado",
                schema: "ir",
                table: "Papel",
                type: "CHAR(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                schema: "ir",
                table: "Papel",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mercado",
                schema: "ir",
                table: "Papel",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "CHAR(1)",
                oldNullable: true);
        }
    }
}
