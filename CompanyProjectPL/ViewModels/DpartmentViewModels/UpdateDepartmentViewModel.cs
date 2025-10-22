using System.ComponentModel.DataAnnotations;

namespace CompanyProjectPL.ViewModels.DpartmentViewModels
{
    public class UpdateDepartmentViewModel
    {
        public int Id { get; set; }
        [MaxLength(10)]
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }

        [Display(Name = "Creation Date")]
        public DateTime CreatedAt { get; set; }
    }
}
