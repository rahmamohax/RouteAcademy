using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session3.Example_2
{
    internal static class SortingStrategies
    {
        //arr[j] >  arr[j + 1]
        public static bool SortAsc(int x, int y)
        {
            return x > y;
        }

        //arr[j] <  arr[j+1]
        public static bool SortDesc(int x, int y)
        {
            return x < y;
        }

        public static bool SortAsc(string? x, string? y)
        {
            return x?.Length > y?.Length;
        }
        public static bool SortDesc(string? x, string? y)
        {
            return x?.Length < y?.Length;
        }
    }
}
