using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore01.Data.Migrations
{
    /// <inheritdoc />
    public partial class createView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create view DepartmentsAndEmps
                                    as
	                                    select d.Id, d.Name [DepartmentName], e.Name EmployeeName
	                                    from Departments d left join Employees e
	                                    on d.Id = e.WorkDepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
