using Microsoft.EntityFrameworkCore.Migrations;

namespace EdicoesEmMassa.Migrations
{
    public partial class CriandoTabelaTemperatura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CodIncubadora",
                table: "Incubadora",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Temperatura",
                columns: table => new
                {
                    IdTemperatura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncubadoraIdIncubadora = table.Column<int>(type: "int", nullable: true),
                    TemperaturaAtual = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperatura", x => x.IdTemperatura);
                    table.ForeignKey(
                        name: "FK_Temperatura_Incubadora_IncubadoraIdIncubadora",
                        column: x => x.IncubadoraIdIncubadora,
                        principalTable: "Incubadora",
                        principalColumn: "IdIncubadora",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Temperatura_IncubadoraIdIncubadora",
                table: "Temperatura",
                column: "IncubadoraIdIncubadora");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Temperatura");

            migrationBuilder.AlterColumn<string>(
                name: "CodIncubadora",
                table: "Incubadora",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
