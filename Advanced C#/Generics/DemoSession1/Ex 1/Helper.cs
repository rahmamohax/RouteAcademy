using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSession1.Ex_1
{
    internal static class Helper<T> where T : class
    {
        public static void Swap(ref T a, ref T b)
        {
            T temp = a;
            a=b;
            b=temp;
        }

        public static int LinearSearch(T[]? arr, T key)
        {
            if (arr is not null && arr.Length>0)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    ///== operator wont work with generics because it can send a userDefined types
                    if (arr[i] == key)
                        return i;
                }
            }
            return -1;
        }
    }
}
