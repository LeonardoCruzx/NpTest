using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NpTest.Migrations
{
    /// <inheritdoc />
    public partial class AdminPasswordHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bidding",
                keyColumn: "Id",
                keyValue: 1,
                column: "OpenDate",
                value: new DateTime(2023, 11, 23, 21, 44, 41, 361, DateTimeKind.Local).AddTicks(5472));

            migrationBuilder.UpdateData(
                table: "Bidding",
                keyColumn: "Id",
                keyValue: 2,
                column: "OpenDate",
                value: new DateTime(2023, 11, 23, 21, 44, 41, 361, DateTimeKind.Local).AddTicks(5483));

            migrationBuilder.UpdateData(
                table: "Bidding",
                keyColumn: "Id",
                keyValue: 3,
                column: "OpenDate",
                value: new DateTime(2023, 11, 23, 21, 44, 41, 361, DateTimeKind.Local).AddTicks(5484));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$04$zF53nha18AKyqWRwVlk87ueW2m0w2w81WGOhzWw.aVrqUvcBXOwEu", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 11, 22, 19, 46, 26, 22, DateTimeKind.Local).AddTicks(7286), "admin", new DateTime(2023, 11, 22, 19, 46, 26, 22, DateTimeKind.Local).AddTicks(7289) });
        }
    }
}
