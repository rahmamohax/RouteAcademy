using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore01.Data.Migrations
{
    /// <inheritdoc />
    public partial class WorkRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkDepartmentId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_WorkDepartmentId",
                table: "Employees",
                column: "WorkDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_WorkDepartmentId",
                table: "Employees",
                column: "WorkDepartmentId",
                principalTable: "Departments",
                principalColumn: "Id"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_WorkDepartmentId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_WorkDepartmentId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "WorkDepartmentId",
                table: "Employees");
        }
    }
}
