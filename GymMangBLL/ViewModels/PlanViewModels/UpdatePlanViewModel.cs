using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangBLL.ViewModels.PlanViewModels
{
    public class UpdatePlanViewModel
    {
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Description { get; set; } = null!;

        [Required]
        [Range(1, 365, ErrorMessage ="Duration must be Between 1 and 365")]
        public int Duration { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
