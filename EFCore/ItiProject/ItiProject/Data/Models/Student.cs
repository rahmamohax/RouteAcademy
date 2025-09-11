using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItiProject.Data.Models
{
    internal class Student
    {
        public int Id { get; set; }

        [Column("FName")]
        [MaxLength(50)]
        public string FirstName { get; set; } = null!;

        [Column("LName")]
        [MaxLength(50)]
        public string? LastName { get; set; }

        [MaxLength(100)]
        public string Address { get; set; } = null!;

        [Range(5,30)]
        public int Age { get; set; }

        [ForeignKey(nameof(Department))]
        public int DeptId { get; set; }
                                              //Type of Nav prop + ID
                                              //Name of Nav prop + ID
                                              //Type of Nav prop + PK Name
                                              //Type of Nav prop + ID
                                              //otherwise you must specify its a FK
        public Department? Department { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
    }
}
