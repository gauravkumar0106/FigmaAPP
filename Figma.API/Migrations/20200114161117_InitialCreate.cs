using Microsoft.EntityFrameworkCore.Migrations;

namespace Figma.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmpName = table.Column<string>(nullable: true),
                    EmpDesignation = table.Column<string>(nullable: true),
                    EmpDepartment = table.Column<string>(nullable: true),
                    EmpManager = table.Column<string>(nullable: true),
                    EmpType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
