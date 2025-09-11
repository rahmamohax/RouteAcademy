using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItiProject.Data.Models
{
    internal class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime HiringDate { get; set; }

        [ForeignKey(nameof(Instructor))]
        public int InstId { get; set; }
        public Instructor Instructor { get; set; }
        public List<Student> Students { get; set; } = null!;
    }
}
