using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProjectBLL.DTOs.DepartmentDtos
{
    public class CreateDepartmentDto
    {
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }

        [Display(Name ="Creation Date")]
        public DateTime CreatedAt { get; set; }
    }
}
