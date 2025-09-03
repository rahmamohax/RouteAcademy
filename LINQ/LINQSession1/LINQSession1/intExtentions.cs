using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQSession1
{
    internal static class intExtentions
    {
        public static int Reverse(this int Number)
        {
            int reverse = 0, reminder;
            while (Number != 0) { 
                reminder = Number % 10;
                reverse = reverse * 10 + reminder;
                Number /= 10;
            }
            return reverse;
        }
    }
}
