using CompanyProjectBLL.DTOs.EmployeeDtos;
using CompanyProjectDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProjectBLL.Factories
{
    public static class EmployeeFactory
    {
        public static EmployeeDto ToEmployeeDto(this Employee employee)
        {
            return new EmployeeDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Age = employee.Age, 
                IsActive = employee.IsActive,
                Salary = employee.Salary,
                Gender = employee.Gender.ToString(),
                EmployeeType = employee.EmployeeType.ToString()                
            };
        }

        public static EmployeeDto ToEmployeeDetailedDto(this Employee employee)
        {
            return new EmployeeDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Age = employee.Age,
                IsActive = employee.IsActive,
                Salary = employee.Salary,
                Gender = employee.Gender.ToString(),
                EmployeeType = employee.EmployeeType.ToString(),
                Address = employee.Address,
                PhoneNumber = employee.PhoneNumber,
                CreatedBy = employee.CreatedBy,
                CreatedOn = employee.CreatedOn.ToString(),
                HiringDate = employee.HiringDate,
                LastModifiedOn = employee.LastModifiedOn.ToString(),
                LastModifiedBy = employee.LastModifiedBy
            };
        }
    }
}
