using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSession5.Built_in_Interfaces
{
    internal class IntComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            int? X= (int?)x;
            int? Y= (int?)y;
            return ( Y.Value.CompareTo(X.Value));
        }
    }
}
