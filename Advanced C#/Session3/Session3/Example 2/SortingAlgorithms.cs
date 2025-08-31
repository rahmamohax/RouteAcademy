using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session3.Example_2
{
    //Non-Generic Delegate
    //public delegate bool StrategyDelegate(int x, int y);

    //Generic Delegate
    //public delegate TRes StrategyDelegate<in T1, in T2, out TRes>(T1 x, T2 y);

    internal static class SortingAlgorithms<T>
    {
        public static void BubbleSort(T[]? arr, Func<T, T, bool>? SortingStrategy)
        {
            if(arr?.Length > 0 && SortingStrategy is not null)
            {
                for (int i = 0; i < arr.Length; i++) { 
                    for (int j = 0; j< arr.Length -1 -i; j++)
                    {
                        //1. if (arr[j] >  arr[j+1])
                        //2. if (arr[j] <  arr[j+1])
                        //Let User Choose Sorting Order at Runtime
                        //Strategy Pattern
                        if (SortingStrategy(arr[j], arr[j+1]))
                                Swap(ref arr[j], ref arr[j + 1]);
                    }
                }
            }
        }
        //public static void BubbleSortDecs(int[]? arr)
        //{
        //    if (arr?.Length > 0)
        //    {
        //        for (int i = 0; i < arr.Length; i++)
        //        {
        //            for (int j = 0; j < arr.Length - 1 - i; j++)
        //            {
        //                if (arr[j] < arr[j + 1])
        //                    Swap(ref arr[j], ref arr[j + 1]);
        //            }
        //        }
        //    }
        //}

        private static void Swap(ref T v1, ref T v2)
        {
            T temp = v1;
            v1 = v2;
            v2 = temp;
        }
    }
}
