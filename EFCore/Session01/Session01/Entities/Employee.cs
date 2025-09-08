using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore01.Entities
{

    //4 Ways for Mapping: [Table, View, Function]
    //1. By Convention [Default]
    //2. Data Annotation [Used for data Validation]
    //3. Fluent APIs
    //4. Class Configuration

    //[Table("Users",Schema = "HR")]
    //internal class Employee
    //{
    //1. By Convention [Default]
    //public int Id { get; set; }  //Eaither Id Or EmployeeId --> Pk: Identity(1,1)
    //public string Name { get; set; }  // Required [Default]  --->  nvarchar(max)
    //public int Age { get; set; }
    //public decimal Salary { get; set; }

    //public string Email { get; set; }
    //public DateTime DateOfCreation { get; set; }

    //}

    //internal class Employee
    //{

    //2. Data Annotation

    //[Key]
    //[DatabaseGenerated(DatabaseGeneratedOption.None)]
    //public int EmpId { get; set; }

    //[Required]
    //[StringLength(50)]
    //[Column("EmpName",TypeName ="varchar")]
    //public string Name { get; set; }

    //[Range(18,60)] //Data Validation for app
    //public int Age { get; set; }

    //public decimal Salary { get; set; }

    //[EmailAddress]
    //public string Email { get; set; }

    //[Phone]
    //public string Phone { get; set; }
    //public DateTime DateOfCreation { get; set; }
    //[StringLength(20)]
    //public string Password { get; set; }

    //[NotMapped]
    //public decimal TotalSalary { get; set; } //Drivved Attribute
    //}

    //3. Fluent APIs
    public class Employee
    {
        public int EmpId { get; set; }  
        public string Name { get; set; }
        public int? Age { get; set; }
        public decimal Salary { get; set; }

        public string Email { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}
