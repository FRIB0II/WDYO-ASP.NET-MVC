using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatDoYouOwn_ASPNET.Migrations
{
    /// <inheritdoc />
    public partial class Computadores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Computador",
                columns: table => new
                {
                    IdComputador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdfUsuario = table.Column<int>(type: "int", nullable: false),
                    Ipv4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UltimoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computador", x => x.IdComputador);
                    table.ForeignKey(
                        name: "FK_Computador_Usuarios_IdfUsuario", // Certifique-se de que "Usuarios" é o nome correto da tabela de usuários
                        column: x => x.IdfUsuario,
                        principalTable: "Usuario", // Tabela referenciada
                        principalColumn: "IdUsuario", // Coluna referenciada
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Computador_IdfUsuario",
                table: "Computador",
                column: "IdfUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Computador");
        }
    }
}
