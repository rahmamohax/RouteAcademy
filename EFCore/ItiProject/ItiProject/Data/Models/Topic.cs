using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItiProject.Data.Models
{
    internal class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Course> Courses { get; set; }
    }
}
