using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkateboardTracker.Migrations
{
    public partial class NewSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "OnLock",
                table: "Tricks",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.InsertData(
                table: "Tricks",
                columns: new[] { "TrickId", "Description", "Location", "Name", "Notes", "OnLock" },
                values: new object[] { 3, "backside pop shuvit heelflig", "in the grass", "inward heel", "safe", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tricks",
                keyColumn: "TrickId",
                keyValue: 3);

            migrationBuilder.AlterColumn<bool>(
                name: "OnLock",
                table: "Tricks",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);
        }
    }
}
