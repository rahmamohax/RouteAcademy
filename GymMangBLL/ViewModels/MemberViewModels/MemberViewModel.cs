using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangBLL.ViewModels.MemberVIewModels
{
    public class MemberViewModel
    {
        public int Id { get; set; }
        public string? Photo { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;

        //Show Details
        public string? PlanName { get; set; }
        public string? DateOfBirth { get; set; }
        public string? MembershipStartDate { get; set; }
        public string? MembershipEndtDate { get; set; }
        public string? Address { get; set; }
    }
}
