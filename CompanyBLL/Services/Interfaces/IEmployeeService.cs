using CompanyProjectBLL.DTOs.EmployeeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProjectBLL.Services.Interfaces
{
    public interface IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetAllEmployees(string? EmployeeSearchName);
        public EmployeeDto? GetEmployeeById(int id);
        public bool AddEmployee(CreateEmployeeDto employeeDto);
        public bool UpdateEmployee(int id, UpdateEmployeeDto employeeDto);
        public bool DeleteEmployee(int id);
    }
}
