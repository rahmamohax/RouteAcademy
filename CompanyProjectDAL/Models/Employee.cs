using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProjectDAL.Models
{
    public enum Gender
    {
        Male = 1,
        Female
    }
    public enum EmployeeType
    {
        PartTime = 1,
        FullTime
    }
    public class Employee : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public bool IsActive { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }

    //[Owned]
    //public class Address()
    //{
    //    public int BuildingNumber { get; set; }
    //    public string Street { get; set; } = string.Empty;
    //    public string City { get; set; } = string.Empty;
    //    public string Country { get; set; } = string.Empty;
    //}
}
