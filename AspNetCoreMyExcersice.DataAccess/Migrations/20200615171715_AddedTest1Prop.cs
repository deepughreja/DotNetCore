using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreMyExcersice.DataAccess.Migrations
{
    public partial class AddedTest1Prop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TestProp",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestProp",
                table: "Employees");
        }
    }
}
