using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatDoYouOwn_ASPNET.Migrations
{
    /// <inheritdoc />
    public partial class Arrumando : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HostName",
                table: "Computador",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Computador",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HostName",
                table: "Computador");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Computador");
        }
    }
}
