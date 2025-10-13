using CompanyProjectBLL.DTOs.DepartmentDtos;
using CompanyProjectDAL.Models;

namespace CompanyProjectBLL.Factories
{
    public static class DepartmentFactory
    {
        public static DepartmentDto ToDepartmentDto(this Department department)
        {
            return new DepartmentDto()
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                Code = department.Code,
                DateOfCreation = department.CreatedOn.ToString()
            };
        }
        public static DepartmentDto ToDepartmentDetailedDto(this Department department)
        {
            return new DepartmentDto()
            {
                Id = department.Id,
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                CreatedBy = department.CreatedBy,
                DateOfCreation = department.CreatedOn.ToString(),
                IsDeleted = department.IsDeleted,
                LastModifiedBy = department.LastModifiedBy
            };
        }

        public static Department AddDepartment(this CreateDepartmentDto department)
        {
            return new Department()
            {
                Name = department.Name,
                Description = department.Description,
                Code = department.Code,
                CreatedOn = department.CreatedAt,            
            };
        }

        public static Department UpdateDepartment(this UpdateDepartmentDto department)
        {
            return new Department()
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                Code = department.Code,
                CreatedOn = department.CreatedAt,
                LastModifiedOn = DateTime.Now
            };
        }
    }
}
