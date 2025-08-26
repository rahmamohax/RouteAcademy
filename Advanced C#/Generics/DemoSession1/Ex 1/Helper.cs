using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSession1.Ex_1
{
        //internal static class Helper<T1, T2> where T1 : class where T2 : struct, IEquatable<T2>
        //internal static class Helper<T> where T : class, IEquatable<T> ,IEqualityComparer<T>
        internal static class Helper<T> where T : IEquatable<T>
        {
        public static void Swap(ref T a, ref T b)
        {
            T temp = a;
            a=b;
            b=temp;
        }

        public static int LinearSearch(T[]? arr, T key, IEqualityComparer<T> comparer)
        {
            if (arr?.Length>0 && key is not null) 
            {
                for (int i = 0; i < arr.Length; i++)
                {
                ///'==' operator wont work with generics of type 'T' because it can send a userDefined types
                    //if (arr[i] == key)// invalid
                    //if (key.Equals(arr[i]))
                    if(comparer.Equals(arr[i], key))
                        return i;
                }
            }
            return -1;
        }
    }
}
