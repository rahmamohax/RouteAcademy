using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore01.Data.Entities.M2M
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        //public List<Course> Courses { get; set; }
        public List<StudentCource> StudentsCources { get; set; } = null!;

    }
}
