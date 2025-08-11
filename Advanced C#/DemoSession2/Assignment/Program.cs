using System.Xml.Linq;

namespace Assignment
{
    class Program
    {
        //public static List<int> ReturnEven(List<int> list)
        //{
        //    List<int> result = new List<int>();

        //    foreach (int item in list)
        //    {
        //        if (item % 2 == 0)
        //            result.Add(item);
        //    }
        //    return result;  
        //}

        public static void PrintGreaterThan(int size, int NoOFQueries)
        {
            int[] array = new int[size];
            int count, num;
            for (int i = 0; i < size; i++)
                while (!int.TryParse(Console.ReadLine(),out array[i]));
            
            for (int i = 0; i < NoOFQueries; i++)
            {
                while (!int.TryParse(Console.ReadLine(), out num));
                count = 0;

                foreach (var item in array)
                    if (item > num) count++;
                Console.WriteLine(count);
            }
        }
        public static void isPlaindrome(int[] array)
        {
            bool isvalid = true;
  
            for (int i = 0; i < array.Length / 2; i++)
            {
                if (array[i] != array[array.Length - i - 1]){
                    isvalid = false;
                    break;
                }
            } 
            Console.WriteLine((isvalid) ? "YES" : "NO");
        }

        static int[] RemoveDuplicates(ref int[] arr)
        {
            return arr.Distinct().ToArray();

        }

        public static void Main(string[] args)
        {
            #region You are given a list of integers. Your task is to find and return a new list containing only the even numbers from the given list.

            //List<int> ints = new List<int> (new int[] {1, 2, 3, 4, 5, 6, 7, 8 } );
            //List<int> result=  ReturnEven(ints);

            //foreach (var item in result)
            //    Console.Write(item + "\t");
            #endregion
            #region implement a custom list called FixedSizeList<T> with a predetermined capacity. This list should not allow more elements than its capacity and should provide clear messages if one tries to exceed it or access invalid indices.

            //Requirements:
            //Create a generic class named FixedSizeList<T>.
            //Implement a constructor that takes the fixed capacity of the list as a parameter.
            //Implement an Add method that adds an element to the list, but throws an exception if the list is already full.
            //Implement a Get method that retrieves an element at a specific index in the list but throws an exception for invalid indices.

            //FixedSizeList<int> list = new FixedSizeList<int>(3);
            //try
            //{
            //    list.Add(1);
            //    list.Add(2);
            //    list.Add(3);

            //    list.Get(2);
            //    list.Get(5);


            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error: {ex.Message}");
            //}

            //try
            //{
            //    list.Add(20);
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error: {ex.Message}");
            //}
            #endregion
            #region Given an array  consists of  numbers with size N and number of queries, in each query you will be given an integer X, and you should print how many numbers in array that is greater than  X.
            //Input
            //3 3                    //Size of array , number of queries
            //11 5 3             //Array 
            //1                      //Query1
            //5                     //Query2
            //13                  //Query 3
            //Output
            //3                   //11,5,3
            //1                  //11
            //0
            //string[] input;
            //int x, y;
            //do
            //{
            //   input= Console.ReadLine().Split(" ");

            //}
            //while (input.Length !=2 ||
            //        !int.TryParse(input[0], out x) ||
            //        !int.TryParse(input[1], out y));

            //PrintGreaterThan(x, y);
            #endregion
            #region Given a number N and an array of N numbers. Determine if it's palindrome or not.
            //int x= 99;
            //string input="";
            //while (!int.TryParse(Console.ReadLine(), out x) || x<=0)
            //{
            //    Console.WriteLine("Enter a valid number:");
            //}
            //int[] nums = null;

            //do
            //{
            //    Console.WriteLine("Input Numbers");
            //    input = Console.ReadLine();
            //    string[] parts = input.Split(' ');
            //    if(parts.All(p => int.TryParse(p, out _)) && parts.Length == x)
            //    {
            //        nums= parts.Select(int.Parse).ToArray();
            //    }
            //} while (nums == null);


            //isPlaindrome(nums);
            #endregion

            #region Given an array, implement a function to remove duplicate elements from an array
            //int[] arr = { 1, 2, 3, 3, 4, 5, 7, 8, 9, 6, 7, 8, 6, 5 };
            //arr =RemoveDuplicates(ref arr);
            //foreach (var item in arr)
            //    Console.Write(item + "\t");

            #endregion

            #region Given an array list, implement a function to remove all odd numbers from it. 

            #endregion

        }
    }

}