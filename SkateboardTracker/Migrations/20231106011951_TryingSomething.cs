using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkateboardTracker.Migrations
{
    public partial class TryingSomething : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SessionTrick",
                columns: table => new
                {
                    SessionsSessionId = table.Column<int>(type: "int", nullable: false),
                    TricksTrickId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionTrick", x => new { x.SessionsSessionId, x.TricksTrickId });
                    table.ForeignKey(
                        name: "FK_SessionTrick_Sessions_SessionsSessionId",
                        column: x => x.SessionsSessionId,
                        principalTable: "Sessions",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionTrick_Tricks_TricksTrickId",
                        column: x => x.TricksTrickId,
                        principalTable: "Tricks",
                        principalColumn: "TrickId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SessionTrick_TricksTrickId",
                table: "SessionTrick",
                column: "TricksTrickId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SessionTrick");
        }
    }
}
