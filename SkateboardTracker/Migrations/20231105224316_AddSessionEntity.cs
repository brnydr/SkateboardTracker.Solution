using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkateboardTracker.Migrations
{
    public partial class AddSessionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Tricks",
                newName: "Obstacle");

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    SessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Location = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.SessionId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TrickSessions",
                columns: table => new
                {
                    TrickSessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    TrickId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrickSessions", x => x.TrickSessionId);
                    table.ForeignKey(
                        name: "FK_TrickSessions_Session_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Session",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrickSessions_Tricks_TrickId",
                        column: x => x.TrickId,
                        principalTable: "Tricks",
                        principalColumn: "TrickId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Tricks",
                keyColumn: "TrickId",
                keyValue: 1,
                column: "Obstacle",
                value: "street area, flatland");

            migrationBuilder.UpdateData(
                table: "Tricks",
                keyColumn: "TrickId",
                keyValue: 2,
                column: "Obstacle",
                value: "4 stair");

            migrationBuilder.UpdateData(
                table: "Tricks",
                keyColumn: "TrickId",
                keyValue: 3,
                columns: new[] { "Description", "Obstacle" },
                values: new object[] { "backside pop shuvit heelflip", "grass" });

            migrationBuilder.CreateIndex(
                name: "IX_TrickSessions_SessionId",
                table: "TrickSessions",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_TrickSessions_TrickId",
                table: "TrickSessions",
                column: "TrickId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrickSessions");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.RenameColumn(
                name: "Obstacle",
                table: "Tricks",
                newName: "Location");

            migrationBuilder.UpdateData(
                table: "Tricks",
                keyColumn: "TrickId",
                keyValue: 1,
                column: "Location",
                value: "Stronger skatepark, street area, flatland");

            migrationBuilder.UpdateData(
                table: "Tricks",
                keyColumn: "TrickId",
                keyValue: 2,
                column: "Location",
                value: "skatepark 4 stair");

            migrationBuilder.UpdateData(
                table: "Tricks",
                keyColumn: "TrickId",
                keyValue: 3,
                columns: new[] { "Description", "Location" },
                values: new object[] { "backside pop shuvit heelflig", "in the grass" });
        }
    }
}
