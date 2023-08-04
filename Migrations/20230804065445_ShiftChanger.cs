using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HourCalcMVC.Migrations
{
    /// <inheritdoc />
    public partial class ShiftChanger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Shift",
                table: "dailyHours",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Shift",
                table: "dailyHours");
        }
    }
}
