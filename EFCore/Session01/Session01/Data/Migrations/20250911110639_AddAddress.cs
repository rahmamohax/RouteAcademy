using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore01.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Address_BlockNo",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_BlockNo",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                table: "Employees");
        }
    }
}
