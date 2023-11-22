using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NpTest.Migrations
{
    /// <inheritdoc />
    public partial class AddedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Bidding",
                keyColumn: "Id",
                keyValue: 1,
                column: "OpenDate",
                value: new DateTime(2023, 11, 22, 19, 46, 26, 21, DateTimeKind.Local).AddTicks(8150));

            migrationBuilder.UpdateData(
                table: "Bidding",
                keyColumn: "Id",
                keyValue: 2,
                column: "OpenDate",
                value: new DateTime(2023, 11, 22, 19, 46, 26, 21, DateTimeKind.Local).AddTicks(8160));

            migrationBuilder.UpdateData(
                table: "Bidding",
                keyColumn: "Id",
                keyValue: 3,
                column: "OpenDate",
                value: new DateTime(2023, 11, 22, 19, 46, 26, 21, DateTimeKind.Local).AddTicks(8161));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "Password", "UpdatedAt", "UserName" },
                values: new object[] { 1, new DateTime(2023, 11, 22, 19, 46, 26, 22, DateTimeKind.Local).AddTicks(7286), "admin", new DateTime(2023, 11, 22, 19, 46, 26, 22, DateTimeKind.Local).AddTicks(7289), "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.UpdateData(
                table: "Bidding",
                keyColumn: "Id",
                keyValue: 1,
                column: "OpenDate",
                value: new DateTime(2023, 11, 21, 18, 56, 3, 556, DateTimeKind.Local).AddTicks(7850));

            migrationBuilder.UpdateData(
                table: "Bidding",
                keyColumn: "Id",
                keyValue: 2,
                column: "OpenDate",
                value: new DateTime(2023, 11, 21, 18, 56, 3, 556, DateTimeKind.Local).AddTicks(7860));

            migrationBuilder.UpdateData(
                table: "Bidding",
                keyColumn: "Id",
                keyValue: 3,
                column: "OpenDate",
                value: new DateTime(2023, 11, 21, 18, 56, 3, 556, DateTimeKind.Local).AddTicks(7861));
        }
    }
}
