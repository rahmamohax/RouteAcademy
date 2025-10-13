using CompanyProjectDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProjectBLL.DTOs.DepartmentDtos
{
    public class DepartmentDto
    {
       // public DepartmentDto(Department department)
       //{
       //     Id = department.Id;
       //     Code = department.Code;
       //     Name = department.Name;
       //     Description = department.Description;
       //     CreatedBy = department.CreatedBy;
       //     DateOfCreation = department.CreatedOn.ToString();
       //     LastModifiedBy = department.LastModifiedBy;
       //     IsDeleted = department.IsDeleted;
       // }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } 
        public string Code { get; set; } = string.Empty;
        public string DateOfCreation { get; set; } = string.Empty;

        //Display
        public int? CreatedBy { get; set; }
        public int? LastModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
