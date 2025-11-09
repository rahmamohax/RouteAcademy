using GymMangDAL.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace GymMangBLL.ViewModels.MemberViewModels
{
    public class CreateMemberViewModel
    {
        [Required(ErrorMessage = "Profile Photo is Required")]
        [Display(Name = "Profile Photo")]
        public IFormFile PhotoFile { get; set; } = null!;

        [Required(ErrorMessage ="Name Field is Required")]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Invalid Input")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage ="Invalid Email Format")]
        [DataType(DataType.EmailAddress)] // suggests previous typed emails
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone is Required")]
        [Phone(ErrorMessage = "Invalid Phone Format")]
        [RegularExpression(@"^(010|011|012|015)\d{8}$", ErrorMessage = "Must be a Valid Egyptian Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "Date of Birth is Required")]
        [DataType(DataType.Date)]
        public DateOnly DateofBirth { get; set; }

        [Required(ErrorMessage = "Gender is Required")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Building Number is Required")]
        [Range(1,9000)]
        public int BuildingNumber { get; set; }

        [Required(ErrorMessage = "Street is Required")]
        [StringLength(30, MinimumLength = 3)]
        public string Street { get; set; } = null!;

        [Required(ErrorMessage = "City is Required")]
        [StringLength(30, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Invalid Input")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "Health Record is Required")]
        public HealthRecordViewModel HealthRecordViewModel { get; set; } = null!;

    }
}
