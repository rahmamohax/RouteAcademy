using AutoMapper;
using CompanyProjectBLL.DTOs.EmployeeDtos;
using CompanyProjectBLL.Factories;
using CompanyProjectBLL.Services.Interfaces;
using CompanyProjectDAL.Models;
using CompanyProjectDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProjectBLL.Services.Classes
{
    public class EmployeeService(IEmployeeRepository _employeeRepository, IMapper _mapper) : IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAll();
            if(employees == null)  return Enumerable.Empty<EmployeeDto>();

            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public EmployeeDto? GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if(employee is null) return null;

            return _mapper.Map<EmployeeDto>(employee);
        }

        public bool AddEmployee(CreateEmployeeDto employeeDto)
        {
            var createdEmp = _mapper.Map<Employee>(employeeDto);
              return _employeeRepository.Add(createdEmp);
        }

        public bool UpdateEmployee(int id, UpdateEmployeeDto employeeDto)
        {
            var existingEmployee = _employeeRepository.GetById(id);
            if (existingEmployee is null) return false;

            // Update the existing tracked entity instead of creating a new one
            existingEmployee.Name = employeeDto.Name;
            existingEmployee.Age = employeeDto.Age ?? existingEmployee.Age;
            existingEmployee.Address = employeeDto.Address ?? existingEmployee.Address;
            existingEmployee.Salary = employeeDto.Salary;
            existingEmployee.IsActive = employeeDto.IsActive;
            existingEmployee.Email = employeeDto.Email ?? existingEmployee.Email;
            existingEmployee.PhoneNumber = employeeDto.PhoneNumber ?? existingEmployee.PhoneNumber;
            existingEmployee.HiringDate = employeeDto.HiringDate.ToDateTime(new TimeOnly());
            existingEmployee.Gender = employeeDto.Gender;
            existingEmployee.EmployeeType = employeeDto.EmployeeType;
            existingEmployee.LastModifiedOn = DateTime.Now;
            existingEmployee.DepartmentId = employeeDto.DepartmentId;

            return _employeeRepository.Update(existingEmployee);
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if(employee is null) return false;

            employee.IsDeleted = true;
            return _employeeRepository.Update(employee);
        }
    }
}
