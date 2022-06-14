using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

#nullable disable

namespace EdicoesEmMassa.Migrations
{
    public partial class CriacaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Incubadora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TemperaturaIdeal = table.Column<double>(type: "double precision", nullable: false),
                    TemperaturaAtual = table.Column<double>(type: "double precision", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incubadora", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TemperaturaHistorico",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TemperaturaAtual = table.Column<double>(type: "double precision", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdIncubadora = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemperaturaHistorico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemperaturaHistorico_Incubadora_IdIncubadora",
                        column: x => x.IdIncubadora,
                        principalTable: "Incubadora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TemperaturaHistorico_IdIncubadora",
                table: "TemperaturaHistorico",
                column: "IdIncubadora");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemperaturaHistorico");

            migrationBuilder.DropTable(
                name: "Incubadora");
        }
    }
}
