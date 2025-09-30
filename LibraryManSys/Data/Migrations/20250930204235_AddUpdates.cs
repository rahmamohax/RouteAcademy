using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManSys.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LName",
                table: "Authors",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "FName",
                table: "Authors",
                newName: "FirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Authors",
                newName: "LName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Authors",
                newName: "FName");
        }
    }
}
