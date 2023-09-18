using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Highscores.Infrastructure.Migrations
{
    public partial class Highscores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Highscores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Player = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false),
                    Score = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Highscores_Id", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Highscores_Id",
                table: "Highscores",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Highscores");
        }
    }
}
