using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciaProjetos.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bugs_Desenvolvedores_CriadorId",
                table: "Bugs");

            migrationBuilder.DropIndex(
                name: "IX_Bugs_CriadorId",
                table: "Bugs");

            migrationBuilder.DropColumn(
                name: "CriadorId",
                table: "Bugs");

            migrationBuilder.AlterColumn<string>(
                name: "Prioridade",
                table: "Bugs",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Bugs",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Bugs");

            migrationBuilder.AlterColumn<string>(
                name: "Prioridade",
                table: "Bugs",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CriadorId",
                table: "Bugs",
                nullable: false,
                defaultValue: 0);

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
    }
}
