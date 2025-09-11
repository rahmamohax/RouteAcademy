using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItiProject.Data.Models
{
    internal class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Bonus { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; } = null!;
        public decimal HourRate { get; set; }

        [ForeignKey(nameof(Department))]
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<Course_Inst> Course_Insts { get; set; }
    }
}
