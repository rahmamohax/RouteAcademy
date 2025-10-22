using System.ComponentModel.DataAnnotations;

namespace CompanyProjectPL.ViewModels.IdentityViewModels
{
    public class ForgetPasswordViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email Can't be Empty")]
        public string Email { get; set; }
    }
}
    