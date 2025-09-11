using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItiProject.Models
{
    internal class Student
    {
        public int Id { get; set; }

        [Column("FName")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Column("LName")]
        [MaxLength(50)]
        public string? LastName { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [Range(5,30)]
        public int Age { get; set; }

        //public int DeptId { get; set; } // I will not add FKs now
    }
}
