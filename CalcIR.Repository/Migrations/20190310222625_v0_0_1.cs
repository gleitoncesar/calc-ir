using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalcIR.Repository.Migrations
{
    public partial class v0_0_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ir");

            migrationBuilder.CreateTable(
                name: "Custodia",
                schema: "ir",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Custodia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotaCorretagem",
                schema: "ir",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaCorretagem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operacao",
                schema: "ir",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Papel",
                schema: "ir",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Papel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resultado",
                schema: "ir",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resultado", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Custodia",
                schema: "ir");

            migrationBuilder.DropTable(
                name: "NotaCorretagem",
                schema: "ir");

            migrationBuilder.DropTable(
                name: "Operacao",
                schema: "ir");

            migrationBuilder.DropTable(
                name: "Papel",
                schema: "ir");

            migrationBuilder.DropTable(
                name: "Resultado",
                schema: "ir");
        }
    }
}
