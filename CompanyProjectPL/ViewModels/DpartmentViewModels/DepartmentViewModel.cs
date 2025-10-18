using System.ComponentModel.DataAnnotations;

namespace CompanyProjectPL.ViewModels.DpartmentViewModels
{
    public class DepartmentViewModel
    {
        [MaxLength(10)]
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }

        [Display(Name = "Creation Date")]
        public DateTime CreatedAt { get; set; }
    }
}
