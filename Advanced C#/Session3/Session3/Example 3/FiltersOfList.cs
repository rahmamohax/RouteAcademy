using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session3.Example_3
{
    internal class FiltersOfList
    {
        public static bool CheckOdd(int x)
        {
            return x % 2 == 1;
        }
        public static bool CheckEven(int x)
        {
            return x % 2 == 0;
        }
        public static bool DivisibleBy7(int x)
        {
            return x % 7 == 0;
        }
        public static bool DivisibleBy10(int x)
        {
            return x % 10 == 0;
        }

        public static bool CheckMoreThan4(string x)
        {
            return x.Length > 4;
        }
        public static bool CheckLessThan4(string x)
        {
            return x.Length < 4;
        }
    }
}
