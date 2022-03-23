using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timesheet_API.Models.Migrations
{
    public partial class ChangedPropertiesForUserProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserTableId",
                schema: "timesheet",
                table: "USER_PROJECT",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "UserTableId",
                schema: "timesheet",
                table: "TASK_TABLE",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserTableId",
                schema: "timesheet",
                table: "LEAD_PROJECT",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TASK_TABLE_USER_TABLE_ID_PROJECT_ID1",
                schema: "timesheet",
                table: "TASK_TABLE",
                columns: new[] { "UserTableId", "PROJECT_ID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TASK_TABLE_USER_TABLE_ID_PROJECT_ID1",
                schema: "timesheet",
                table: "TASK_TABLE");

            migrationBuilder.DropColumn(
                name: "UserTableId",
                schema: "timesheet",
                table: "USER_PROJECT");

            migrationBuilder.DropColumn(
                name: "UserTableId",
                schema: "timesheet",
                table: "TASK_TABLE");

            migrationBuilder.DropColumn(
                name: "UserTableId",
                schema: "timesheet",
                table: "LEAD_PROJECT");
        }
    }
}
