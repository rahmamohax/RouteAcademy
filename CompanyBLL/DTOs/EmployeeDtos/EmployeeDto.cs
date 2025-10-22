using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProjectBLL.DTOs.EmployeeDtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }
        public bool IsActive { get; set; }
        public decimal Salary { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string EmployeeType { get; set; } = string.Empty;

        //Details
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? HiringDate { get; set; }
        public int? CreatedBy { get; set; }
        public string? CreatedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public string? LastModifiedOn { get; set; }
        public int? DepartmentId { get; set; }
        public string? Department { get; set; }
    }
}
