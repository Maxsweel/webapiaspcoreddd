using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLib.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100) CHARACTER SET utf8mb4", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(100) CHARACTER SET utf8mb4", maxLength: 100, nullable: true),
                    Telefone = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
