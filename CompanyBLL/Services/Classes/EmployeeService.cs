using AutoMapper;
using CompanyProjectBLL.DTOs.EmployeeDtos;
using CompanyProjectBLL.Services.AttachmentService;
using CompanyProjectBLL.Services.Interfaces;
using CompanyProjectDAL.Models;
using CompanyProjectDAL.Repositories.Interfaces;


namespace CompanyProjectBLL.Services.Classes
{
    public class EmployeeService(IUnitOfWork _unitOfWork, IMapper _mapper, IAttachmentService _attachmentService) : IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetAllEmployees(string? EmployeeSearchName)
        {
            IEnumerable<Employee> employees;
            if(string.IsNullOrEmpty(EmployeeSearchName))
                employees = _unitOfWork.EmployeeRepository.GetAll();

            else 
                employees = _unitOfWork.EmployeeRepository.GetAll(x => x.Name.ToLower().Contains(EmployeeSearchName.ToLower()));
            if(employees == null)  return Enumerable.Empty<EmployeeDto>();

            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public EmployeeDto? GetEmployeeById(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            if(employee is null) return null;

            return _mapper.Map<EmployeeDto>(employee);
        }

        public bool AddEmployee(CreateEmployeeDto employeeDto)
        {
            var createdEmp = _mapper.Map<Employee>(employeeDto);

            if (employeeDto.Img is not null)
                createdEmp.ImgName = _attachmentService.Upload(employeeDto.Img, "ProfilePhotos");

            _unitOfWork.EmployeeRepository.Add(createdEmp);

            return _unitOfWork.SaveChanges();
        }

        public bool UpdateEmployee(int id, UpdateEmployeeDto employeeDto)
        {
            var existingEmployee = _mapper.Map<Employee>(employeeDto);

            existingEmployee.LastModifiedOn = DateTime.Now;
<<<<<<< HEAD
            // Update the existing tracked entity instead of creating a new one
            //existingEmployee.Name = employeeDto.Name;
            //existingEmployee.Age = employeeDto.Age ?? existingEmployee.Age;
            //existingEmployee.Address = employeeDto.Address ?? existingEmployee.Address;
            //existingEmployee.Salary = employeeDto.Salary;
            //existingEmployee.IsActive = employeeDto.IsActive;
            //existingEmployee.Email = employeeDto.Email ?? existingEmployee.Email;
            //existingEmployee.PhoneNumber = employeeDto.PhoneNumber ?? existingEmployee.PhoneNumber;
            //existingEmployee.HiringDate = employeeDto.HiringDate.ToDateTime(new TimeOnly());
            //existingEmployee.Gender = employeeDto.Gender;
            //existingEmployee.EmployeeType = employeeDto.EmployeeType;
            //existingEmployee.DepartmentId = employeeDto.DepartmentId;
=======
>>>>>>> parent of 6ec52a5 (Demo Session 07)

            _unitOfWork.EmployeeRepository.Update(existingEmployee);
            return _unitOfWork.SaveChanges();
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            if(employee is null) return false;

            employee.IsDeleted = true;
            _unitOfWork.EmployeeRepository.Update(employee);
            return _unitOfWork.SaveChanges();
        }
    }
}
