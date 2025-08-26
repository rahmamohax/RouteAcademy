using DemoSession1.Ex_2;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSession1.EqualityComparer
{
    internal class EmpNameEquComp : IEqualityComparer<Employee>
    {
        public bool Equals(Employee? x, Employee? y)
        {
            //return x?.Name == y?.Name;

            ///x == y : Same Object => True
            ///x , y both Null => True
            ///x is Null => False
            ///y is Null => False
            ///x != y
            ///x.Name == y.Name => True
            ///x.Name != y.Name => False
            
            if (ReferenceEquals(x, y)) return true;
            if (x is  null || y is null) return false;
            return string.Equals(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);

        }

        public int GetHashCode([DisallowNull] Employee obj)
        {
            return obj.Name?.GetHashCode() ?? 0 ;
        }
    }
}
