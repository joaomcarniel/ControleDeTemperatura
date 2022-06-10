using Microsoft.EntityFrameworkCore.Migrations;

namespace EdicoesEmMassa.Migrations
{
    public partial class CriandoTabelaContatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Incubadora",
                columns: table => new
                {
                    IdIncubadora = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodIncubadora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemperaturaFixada = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incubadora", x => x.IdIncubadora);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incubadora");
        }
    }
}
