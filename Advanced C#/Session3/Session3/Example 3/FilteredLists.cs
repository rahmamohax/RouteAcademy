using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session3.Example_3
{
    //public delegate bool FilterNumbersDelegate<T>(T x);
    internal static class FilteredLists
    {
        public static List<T> FilterElements<T>(List<T>? list, Predicate<T>? filter)
        {
            List<T> result = new List<T>();
            if (list?.Count > 0 && filter is not null) {
                for (int i = 0; i < list.Count; i++) 
                    if (filter(list[i])) result.Add(list[i]);
                
            }
            return result;
        }
    }
}
