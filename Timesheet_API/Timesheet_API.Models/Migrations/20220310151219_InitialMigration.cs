using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timesheet_API.Models.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "timesheet");

            migrationBuilder.CreateTable(
                name: "CATEGORY",
                schema: "timesheet",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CATEGORY_NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORY", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "COUNTRY",
                schema: "timesheet",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COUNTRY_NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COUNTRY", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ROLE_TABLE",
                schema: "timesheet",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ROLE_NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE_TABLE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CLIENT",
                schema: "timesheet",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COUNTRY_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CLIENT_NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CLIENT_ADDRESS = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CLIENT_CITY = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CLIENT_ZIP_CODE = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CLIENT_COUNTRY",
                        column: x => x.COUNTRY_ID,
                        principalSchema: "timesheet",
                        principalTable: "COUNTRY",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "USER_TABLE",
                schema: "timesheet",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ROLE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EMAIL = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    USER_PASSWORD = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FIRST_NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LAST_NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    HOURS_PER_WEEK = table.Column<int>(type: "int", nullable: false),
                    USER_STATUS = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_TABLE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USER_ROLE",
                        column: x => x.ROLE_ID,
                        principalSchema: "timesheet",
                        principalTable: "ROLE_TABLE",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PROJECT",
                schema: "timesheet",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CLIENT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PROJECT_NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PROJECT_DESCRIPTION = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    PROJECT_STATUS = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PROJECT_CLIENT",
                        column: x => x.CLIENT_ID,
                        principalSchema: "timesheet",
                        principalTable: "CLIENT",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "USER_PROJECT",
                schema: "timesheet",
                columns: table => new
                {
                    USER_TABLE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PROJECT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_PROJECT", x => new { x.USER_TABLE_ID, x.PROJECT_ID });
                    table.ForeignKey(
                        name: "FK_USER_PROJECT_PROJECT",
                        column: x => x.PROJECT_ID,
                        principalSchema: "timesheet",
                        principalTable: "PROJECT",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_USER_PROJECT_USER_TABLE",
                        column: x => x.USER_TABLE_ID,
                        principalSchema: "timesheet",
                        principalTable: "USER_TABLE",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "LEAD_PROJECT",
                schema: "timesheet",
                columns: table => new
                {
                    USER_TABLE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PROJECT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LEAD_PROJECT", x => new { x.USER_TABLE_ID, x.PROJECT_ID });
                    table.ForeignKey(
                        name: "FK_LEAD_PROJECT_USER_PROJECT",
                        columns: x => new { x.USER_TABLE_ID, x.PROJECT_ID },
                        principalSchema: "timesheet",
                        principalTable: "USER_PROJECT",
                        principalColumns: new[] { "USER_TABLE_ID", "PROJECT_ID" });
                });

            migrationBuilder.CreateTable(
                name: "TASK_TABLE",
                schema: "timesheet",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USER_TABLE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PROJECT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CATEGORY_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TASK_DESCRIPTION = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    TASK_TIME = table.Column<decimal>(type: "numeric(4,2)", nullable: false),
                    TASK_OVERTIME = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    TASK_DATE = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TASK_TABLE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TASK_CATEGORY",
                        column: x => x.CATEGORY_ID,
                        principalSchema: "timesheet",
                        principalTable: "CATEGORY",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TASK_USER_PROJECT",
                        columns: x => new { x.USER_TABLE_ID, x.PROJECT_ID },
                        principalSchema: "timesheet",
                        principalTable: "USER_PROJECT",
                        principalColumns: new[] { "USER_TABLE_ID", "PROJECT_ID" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_CLIENT_COUNTRY_ID",
                schema: "timesheet",
                table: "CLIENT",
                column: "COUNTRY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECT_CLIENT_ID",
                schema: "timesheet",
                table: "PROJECT",
                column: "CLIENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_TABLE_CATEGORY_ID",
                schema: "timesheet",
                table: "TASK_TABLE",
                column: "CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_TABLE_USER_TABLE_ID_PROJECT_ID",
                schema: "timesheet",
                table: "TASK_TABLE",
                columns: new[] { "USER_TABLE_ID", "PROJECT_ID" });

            migrationBuilder.CreateIndex(
                name: "IX_USER_PROJECT_PROJECT_ID",
                schema: "timesheet",
                table: "USER_PROJECT",
                column: "PROJECT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_TABLE_ROLE_ID",
                schema: "timesheet",
                table: "USER_TABLE",
                column: "ROLE_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LEAD_PROJECT",
                schema: "timesheet");

            migrationBuilder.DropTable(
                name: "TASK_TABLE",
                schema: "timesheet");

            migrationBuilder.DropTable(
                name: "CATEGORY",
                schema: "timesheet");

            migrationBuilder.DropTable(
                name: "USER_PROJECT",
                schema: "timesheet");

            migrationBuilder.DropTable(
                name: "PROJECT",
                schema: "timesheet");

            migrationBuilder.DropTable(
                name: "USER_TABLE",
                schema: "timesheet");

            migrationBuilder.DropTable(
                name: "CLIENT",
                schema: "timesheet");

            migrationBuilder.DropTable(
                name: "ROLE_TABLE",
                schema: "timesheet");

            migrationBuilder.DropTable(
                name: "COUNTRY",
                schema: "timesheet");
        }
    }
}
