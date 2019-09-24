using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciaProjetos.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desenvolvedores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Senha = table.Column<string>(maxLength: 45, nullable: false),
                    EAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desenvolvedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    DataEntrega = table.Column<DateTime>(nullable: false),
                    Solicitante = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DesenvolvedorProjeto",
                columns: table => new
                {
                    DesenvolvedorId = table.Column<int>(nullable: false),
                    ProjetoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesenvolvedorProjeto", x => new { x.DesenvolvedorId, x.ProjetoId });
                    table.ForeignKey(
                        name: "FK_DesenvolvedorProjeto_Desenvolvedores_DesenvolvedorId",
                        column: x => x.DesenvolvedorId,
                        principalTable: "Desenvolvedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DesenvolvedorProjeto_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requisitos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false),
                    Observacoes = table.Column<string>(maxLength: 100, nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataEntrega = table.Column<DateTime>(nullable: false),
                    EFuncional = table.Column<bool>(nullable: false),
                    ProjetoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisitos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requisitos_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bugs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DesenvolvedorId = table.Column<int>(nullable: false),
                    RequisitoId = table.Column<int>(nullable: false),
                    Prioridade = table.Column<string>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    CriadorId = table.Column<int>(nullable: false),
                    FoiResolvido = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bugs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bugs_Desenvolvedores_CriadorId",
                        column: x => x.CriadorId,
                        principalTable: "Desenvolvedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bugs_Desenvolvedores_DesenvolvedorId",
                        column: x => x.DesenvolvedorId,
                        principalTable: "Desenvolvedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bugs_Requisitos_RequisitoId",
                        column: x => x.RequisitoId,
                        principalTable: "Requisitos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DesenvolvedorRequisito",
                columns: table => new
                {
                    DesenvolvedorId = table.Column<int>(nullable: false),
                    RequisitoId = table.Column<int>(nullable: false),
                    TempoGasto = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesenvolvedorRequisito", x => new { x.DesenvolvedorId, x.RequisitoId });
                    table.ForeignKey(
                        name: "FK_DesenvolvedorRequisito_Desenvolvedores_DesenvolvedorId",
                        column: x => x.DesenvolvedorId,
                        principalTable: "Desenvolvedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DesenvolvedorRequisito_Requisitos_RequisitoId",
                        column: x => x.RequisitoId,
                        principalTable: "Requisitos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_CriadorId",
                table: "Bugs",
                column: "CriadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_DesenvolvedorId",
                table: "Bugs",
                column: "DesenvolvedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_RequisitoId",
                table: "Bugs",
                column: "RequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_DesenvolvedorProjeto_ProjetoId",
                table: "DesenvolvedorProjeto",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_DesenvolvedorRequisito_RequisitoId",
                table: "DesenvolvedorRequisito",
                column: "RequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisitos_ProjetoId",
                table: "Requisitos",
                column: "ProjetoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bugs");

            migrationBuilder.DropTable(
                name: "DesenvolvedorProjeto");

            migrationBuilder.DropTable(
                name: "DesenvolvedorRequisito");

            migrationBuilder.DropTable(
                name: "Desenvolvedores");

            migrationBuilder.DropTable(
                name: "Requisitos");

            migrationBuilder.DropTable(
                name: "Projetos");
        }
    }
}
