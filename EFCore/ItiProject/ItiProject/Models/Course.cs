using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItiProject.Models
{
    internal class Course
    {
        public int Id { get; set; }
        public TimeSpan Duration { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
