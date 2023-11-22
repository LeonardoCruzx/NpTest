using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NpTest.Migrations
{
    /// <inheritdoc />
    public partial class Firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bidding",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    OpenDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bidding", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Bidding",
                columns: new[] { "Id", "Description", "Number", "OpenDate", "Status" },
                values: new object[,]
                {
                    { 1, "First bidding", 1, new DateTime(2023, 11, 21, 18, 56, 3, 556, DateTimeKind.Local).AddTicks(7850), 0 },
                    { 2, "Second bidding", 2, new DateTime(2023, 11, 21, 18, 56, 3, 556, DateTimeKind.Local).AddTicks(7860), 0 },
                    { 3, "Third bidding", 3, new DateTime(2023, 11, 21, 18, 56, 3, 556, DateTimeKind.Local).AddTicks(7861), 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bidding");
        }
    }
}
