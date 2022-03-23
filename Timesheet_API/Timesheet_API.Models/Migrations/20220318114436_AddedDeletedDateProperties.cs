using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timesheet_API.Models.Migrations
{
    public partial class AddedDeletedDateProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                schema: "timesheet",
                table: "USER_PROJECT",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                schema: "timesheet",
                table: "ROLE_TABLE",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                schema: "timesheet",
                table: "PROJECT",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                schema: "timesheet",
                table: "LEAD_PROJECT",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                schema: "timesheet",
                table: "CLIENT",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                schema: "timesheet",
                table: "CATEGORY",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedDate",
                schema: "timesheet",
                table: "USER_PROJECT");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                schema: "timesheet",
                table: "ROLE_TABLE");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                schema: "timesheet",
                table: "PROJECT");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                schema: "timesheet",
                table: "LEAD_PROJECT");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                schema: "timesheet",
                table: "CLIENT");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                schema: "timesheet",
                table: "CATEGORY");
        }
    }
}
