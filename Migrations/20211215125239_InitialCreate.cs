using Microsoft.EntityFrameworkCore.Migrations;

namespace criptomonedas.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Criptomoneda",
                columns: table => new
                {
                    moneda = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    lastValor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    maxValor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criptomoneda", x => x.moneda);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Criptomoneda");
        }
    }
}
