using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore01.Data.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public  string Name { get; set; }

        #region 1 to many Relation
        public virtual List<Employee> Employees { get; set; }
        #endregion

        #region 1 to 1 Relation

        [ForeignKey(nameof(Manager))]
        public int ManagerId { get; set; } 
        public virtual Employee Manager { get; set; } //navigationla property 
        #endregion
    }
}
