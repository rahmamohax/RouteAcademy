using Assignment;
using System.Collections;

namespace assignment
{
    class Program
    {
        public static void ReverseArrayList(ArrayList list) {
            int left = 0;
            int right = list.Count -1;

            while (left < right) { 
                var temp = list[left];
                list[left] = list[right];
                list[right] = temp;

                left++;
                right--;

            }
        }
        static List<int> GetEvenNumbers(List<int> list)
        {
            List<int> evenNums = new List<int>();
            foreach (var item in list)
                if (item %2 ==0 )
                    evenNums.Add(item);
            return evenNums;
        }

        static void Main(string[] args)
        {
            #region Create a generic Range<T> class that represents a range of values from a minimum value to a maximum value. 

            //Range<int> intRange = new Range<int>(10, 20);
            //Console.WriteLine("Is 15 in Range? " + intRange.IsInRange(15));
            //Console.WriteLine("Lenght: " + intRange.Length());

            //Console.WriteLine("-------------------------------------------------");
            //Range<double> stringRange = new Range<double>(10.2, 50.5);
            //Console.WriteLine("Is 2.5 in Range? " + stringRange.IsInRange(2.5));
            //Console.WriteLine("Lenght: " + stringRange.Length());

            #endregion
            #region You are given an ArrayList containing a sequence of elements. try to reverse the order of elements in the ArrayList in-place

            //ArrayList arrayList = new ArrayList() { 5, 10, 15, 20, 25, 30 };

            //Console.WriteLine("List before Reverse: " + string.Join(", ", arrayList.ToArray()));
            //ReverseArrayList(arrayList);
            //Console.WriteLine("List after Reverse: " + string.Join(", ", arrayList.ToArray()));

            #endregion
            #region You are given a list of integers. Your task is to find and return a new list containing only the even numbers from the given list.

            //List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            
            //Console.WriteLine("Even Numbers: " + string.Join(", ", GetEvenNumbers(list)));

            #endregion

        }
    }
}
