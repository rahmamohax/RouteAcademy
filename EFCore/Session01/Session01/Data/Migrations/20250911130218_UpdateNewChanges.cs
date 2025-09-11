using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore01.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNewChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_Street",
                table: "Employees",
                newName: "EmpAddress_Street");

            migrationBuilder.RenameColumn(
                name: "Address_Country",
                table: "Employees",
                newName: "EmpAddress_Country");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "Employees",
                newName: "EmpAddress_City");

            migrationBuilder.RenameColumn(
                name: "Address_BlockNo",
                table: "Employees",
                newName: "EmpAddress_BlockNo");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Employees",
                newName: "EmailAddress");

            migrationBuilder.RenameColumn(
                name: "DeptName",
                table: "Departments",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "WorkDepartmentId",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmpAddress_Street",
                table: "Employees",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "EmpAddress_Country",
                table: "Employees",
                newName: "Address_Country");

            migrationBuilder.RenameColumn(
                name: "EmpAddress_City",
                table: "Employees",
                newName: "Address_City");

            migrationBuilder.RenameColumn(
                name: "EmpAddress_BlockNo",
                table: "Employees",
                newName: "Address_BlockNo");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Employees",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Departments",
                newName: "DeptName");

            migrationBuilder.AlterColumn<int>(
                name: "WorkDepartmentId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
