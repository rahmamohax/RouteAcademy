using CompanyProjectBLL.DTOs.DepartmentDtos;
using CompanyProjectBLL.Factories;
using CompanyProjectBLL.Services.Interfaces;
using CompanyProjectDAL.Models;
using CompanyProjectDAL.Repositories.Interfaces;

namespace CompanyProjectBLL.Services.Classes
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            if (departments is null) return Enumerable.Empty<DepartmentDto>();
            //return departments.Select(x => new DepartmentDto
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Description= x.Description,
            //    Code = x.Code,
            //    DateOfCreation= x.CreatedOn.ToString(),
            //});
            return departments.Select(x => x.ToDepartmentDto());
        }

        public DepartmentDto? GetDepartmentById(int id)
        {
            var department= _unitOfWork.DepartmentRepository.GetById(id);
            if (department is null) return null;

            return department.ToDepartmentDetailedDto();
        }

        public bool DeleteDepartment(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);
            if (department is null) return false;
             _unitOfWork.DepartmentRepository.Delete(department);
            return _unitOfWork.SaveChanges();
        }

        public bool AddDepartment(CreateDepartmentDto departmentDto)
        {
             _unitOfWork.DepartmentRepository.Add(departmentDto.AddDepartment());
            return _unitOfWork.SaveChanges();

        }

        public bool UpdateDepartment(int id, UpdateDepartmentDto departmentDto)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);
            if (department is null) return false;

            //return _departmentRepository.Update(departmentDto.UpdateDepartment());
            // Update the existing tracked entity instead of creating a new one
            department.Name = departmentDto.Name;
            department.Description = departmentDto.Description;
            department.Code = departmentDto.Code;
            department.LastModifiedOn = DateTime.Now;

             _unitOfWork.DepartmentRepository.Update(department);
            return _unitOfWork.SaveChanges();
        }
    }
}
