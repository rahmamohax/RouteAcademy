using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangBLL.ViewModels.MemberVIewModels
{
    public class HealthRecordViewModel
    {
        [Required(ErrorMessage = "Height is Required")]
        [Range(1,250)]
        public decimal Height { get; set; }

        [Required(ErrorMessage = "Weight is Required")]
        [Range(1,500)]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "Blood Type is Required")]
        [StringLength(3)]
        public string BloodType { get; set; } = null!;
        public string? Note { get; set; }

    }
}
