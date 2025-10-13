using CompanyProjectBLL.DTOs.DepartmentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProjectBLL.Services.Interfaces
{
    public interface IDepartmentService
    {
        public IEnumerable<DepartmentDto> GetAllDepartments();
        public DepartmentDto? GetDepartmentDetails(int id);
        public bool AddDepartment(int id, UpdateDepartmentDto departmentDto);
        public bool DeleteDepartment(int id);

    }
}
