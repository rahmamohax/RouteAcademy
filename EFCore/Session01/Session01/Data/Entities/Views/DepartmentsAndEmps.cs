using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore01.Data.Entities.Views
{
    public class DepartmentsAndEmps
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string? EmployeeName { get; set; }
    }
}
