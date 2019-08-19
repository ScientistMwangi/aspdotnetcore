using Microsoft.EntityFrameworkCore.Migrations;

namespace Configs.Migrations
{
    public partial class employeeSeedMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DbSetEmployees",
                columns: new[] { "Id", "Department", "Email", "Name" },
                values: new object[] { 2, 1, "sa@gmail.com", "mwangi" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DbSetEmployees",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
