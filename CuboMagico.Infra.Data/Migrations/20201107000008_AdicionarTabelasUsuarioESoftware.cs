using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CuboMagico.Infra.Data.Migrations
{
    public partial class AdicionarTabelasUsuarioESoftware : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(128)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(128)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(128)", nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "softwares",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(128)", nullable: false),
                    Vigente = table.Column<bool>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    UsuarioID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_softwares", x => x.ID);
                    table.ForeignKey(
                        name: "FK_softwares_usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_softwares_DataCadastro",
                table: "softwares",
                column: "DataCadastro");

            migrationBuilder.CreateIndex(
                name: "IX_softwares_UsuarioID",
                table: "softwares",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_softwares_Vigente",
                table: "softwares",
                column: "Vigente");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_DataCadastro",
                table: "usuarios",
                column: "DataCadastro");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_Email",
                table: "usuarios",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "softwares");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
