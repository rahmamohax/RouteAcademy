using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSession5.Built_in_Interfaces
{
    internal class EmployeeComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            Employee? empX = (Employee?)x;
            Employee? empY = (Employee?)y;

            //return this.Compare(empX?.Id, empY?.Id);
            return empX?.Id.CompareTo(empY?.Id) ?? (empY is null ? 0 : -1);
        }
    }
}
