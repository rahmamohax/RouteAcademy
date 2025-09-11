using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItiProject.Data.Models
{
    internal class Course
    {
        public int Id { get; set; }
        public TimeSpan Duration { get; set; }
        public string Name { get; set; } = null!;  // Null-Forgiving Operator
                                                   // I know this is not actually null at runtime, so stop warning me.
        public /*required*/ string? Description { get; set; } //or add required

        public int TopicId { get; set; }
        public Topic Topic { get; set; }

        public List<Course_Inst> Course_Insts { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }

    }
}
