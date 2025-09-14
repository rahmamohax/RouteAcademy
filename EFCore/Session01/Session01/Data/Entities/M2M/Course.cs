using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore01.Data.Entities.M2M
{
    public class Course
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        //public List<Student> Students { get; set; }
        public virtual List<StudentCource> StudentsCources { get; set; } 

    }
}
