using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreMyExcersice.DataAccess.Migrations
{
    public partial class IdentityUser_Extended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestProp",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TestProp2",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "TestProp",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TestProp2",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
