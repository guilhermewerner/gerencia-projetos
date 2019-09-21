using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciaProjetos.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "TempoGasto",
                table: "DesenvolvedorRequisito",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "CriadorId",
                table: "Bugs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Bugs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "FoiResolvido",
                table: "Bugs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Prioridade",
                table: "Bugs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_CriadorId",
                table: "Bugs",
                column: "CriadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bugs_Desenvolvedores_CriadorId",
                table: "Bugs",
                column: "CriadorId",
                principalTable: "Desenvolvedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bugs_Desenvolvedores_CriadorId",
                table: "Bugs");

            migrationBuilder.DropIndex(
                name: "IX_Bugs_CriadorId",
                table: "Bugs");

            migrationBuilder.DropColumn(
                name: "TempoGasto",
                table: "DesenvolvedorRequisito");

            migrationBuilder.DropColumn(
                name: "CriadorId",
                table: "Bugs");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Bugs");

            migrationBuilder.DropColumn(
                name: "FoiResolvido",
                table: "Bugs");

            migrationBuilder.DropColumn(
                name: "Prioridade",
                table: "Bugs");
        }
    }
}
