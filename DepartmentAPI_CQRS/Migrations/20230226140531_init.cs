using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DepartmentAPI_CQRS.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    parentDepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Departments_Departments_parentDepartmentId",
                        column: x => x.parentDepartmentId,
                        principalTable: "Departments",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_parentDepartmentId",
                table: "Departments",
                column: "parentDepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
