using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timesheet_API.Models.Migrations
{
    public partial class ChangedCountryColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "timesheet",
                table: "COUNTRY");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "timesheet",
                table: "COUNTRY",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
