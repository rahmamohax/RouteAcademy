using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyProjectDAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgName",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgName",
                table: "Employee");
        }
    }
}
