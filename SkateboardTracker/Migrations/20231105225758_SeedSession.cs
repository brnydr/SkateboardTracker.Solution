using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkateboardTracker.Migrations
{
    public partial class SeedSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Session",
                columns: new[] { "SessionId", "Date", "Location" },
                values: new object[] { 1, new DateTime(2023, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ed Benedict Skatepark" });

            migrationBuilder.InsertData(
                table: "Session",
                columns: new[] { "SessionId", "Date", "Location" },
                values: new object[] { 2, new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "TRON" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Session",
                keyColumn: "SessionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Session",
                keyColumn: "SessionId",
                keyValue: 2);
        }
    }
}
