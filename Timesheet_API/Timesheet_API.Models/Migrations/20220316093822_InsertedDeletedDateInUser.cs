using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timesheet_API.Models.Migrations
{
    public partial class InsertedDeletedDateInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                schema: "timesheet",
                table: "USER_TABLE",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "USERNAME",
                schema: "timesheet",
                table: "USER_TABLE",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedDate",
                schema: "timesheet",
                table: "USER_TABLE");

            migrationBuilder.DropColumn(
                name: "USERNAME",
                schema: "timesheet",
                table: "USER_TABLE");
        }
    }
}
