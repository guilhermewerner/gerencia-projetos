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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempoGasto",
                table: "DesenvolvedorRequisito");
        }
    }
}
