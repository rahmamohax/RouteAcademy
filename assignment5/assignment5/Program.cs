using System;
using System.Linq;
class Program
{
    static void Main()
    {

        #region 19- . Write a program that prints an identity matrix using for loop, in other words takes a value n from the user and shows the identity table of size n * n.
        Console.Write("input value n: ");
        int n = int.Parse(Console.ReadLine());
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (count == i && count == j)
                {
                    Console.Write("1 ");
                    count++;
                }
                else Console.Write("0 ");
            }
            Console.WriteLine();
        }
        #endregion

        #region 20- Write a program in C# Sharp to find the sum of all elements of the array.
        Console.Write("input array size: ");
        int arrSize = int.Parse(Console.ReadLine());
        Console.Write("input elements seperated by space: ");
        string nums = Console.ReadLine();
        int[] arr = nums.Split(new[] { ' ' }).Select(int.Parse).ToArray();
        int sum = 0;
        foreach (int i in arr)
        {
            sum += i;
        }
        Console.WriteLine("Summation of array is: " + sum);
        #endregion

        #region 21- Write a program in C# Sharp to merge two arrays of the same size sorted in ascending order.

        Console.Write("Input first array numbers (space-separated): ");
        int[] arr1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        Console.Write("Input second array numbers (same size): ");
        int[] arr2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        if (arr1.Length != arr2.Length)
        {
            Console.WriteLine("Error: Arrays must be of the same size!");
            return;
        }

        int[] merged = arr1.Concat(arr2).OrderBy(x => x).ToArray();

        Console.WriteLine("\nMerged sorted array:");
        Console.WriteLine(string.Join(" ", merged));

        #endregion

        #region 22- Write a program in C# Sharp to count the frequency of each element of an array.
        Console.WriteLine("Input elements in array: ");
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        Dictionary<int, int> freq = new Dictionary<int, int>();

        foreach (int i in array)
        {
            if (freq.ContainsKey(i))
                freq[i]++;

            else freq[i] = 1;
        }

        Console.WriteLine(" Element : Frequency");
        foreach (var num in freq.OrderBy(x => x.Key))
        {
            Console.WriteLine($"{num.Key} : {num.Value}");
        }
        #endregion

        #region 23- Write a program in C# Sharp to find maximum and minimum element in an array
        Console.Write("Input elements in array: ");
        int[] elem = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int max = 0, min = 9999;
        foreach (int i in elem)
        {
            max = Math.Max(max, i);
            min = Math.Min(min, i);
        }

        Console.WriteLine($"Maximum number in array is: {max}");
        Console.WriteLine($"Minimum number in array is: {min}");

        #endregion

        #region 24- Write a program in C# Sharp to find the second largest element in an array.
        Console.Write("Input elements in array: ");
        int[] elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        elements.OrderBy(x => x);
        Console.WriteLine($"Second largest element in an array is : {elements[elements.Length - 2]}");

        #endregion

        #region 25- Write a program find the longest distance between Two equal cells
        Console.WriteLine("Input elements in array: ");
        int[] array1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        Dictionary<int, int> firstOccurence = new Dictionary<int, int>();
        int maxDistance = -1;

        for (int i = 0; i < array1.Length; i++)
        {
            if (!firstOccurence.ContainsKey(array1[i]))
                firstOccurence[array1[i]] = i;

            else
            {
                int distance = i - firstOccurence[array1[i]] - 1;
                if (distance > maxDistance)
                    maxDistance = distance;
            }
        }
        if (maxDistance == -1)
            Console.WriteLine("No Occurence happened");
        else Console.WriteLine($"Longest distance between equal elements: {maxDistance} cells");
        #endregion

        #region 26- Given a list of space separated words, reverse the order of the words.
        string[] strings = Console.ReadLine().Split(' ');
        Array.Reverse(strings);
        foreach (string s in strings)
        {
            Console.Write(s + " ");
        }
        #endregion

        #region 27- Write a program to create two multidimensional arrays of same size. Accept value from user and store them in first array. Now copy all the elements of first array on second array and print second array.
        Console.Write("Enter No. of Rows: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Enter No. of Columns: ");
        int cols = int.Parse(Console.ReadLine());
        int[,] FstArr = new int[rows, cols];
        int[,] SecArr = new int[rows, cols];

        Console.WriteLine("\nEnter elements for the first array:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"Enter element at position [{i},{j}]: ");
                FstArr[i, j] = int.Parse(Console.ReadLine());
            }
        }

        Array.Copy(FstArr, SecArr, FstArr.Length);
        Console.WriteLine("\nElements in the second array:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(SecArr[i, j] + "\t");
            }
            Console.WriteLine();
        }

        #endregion

        #region 28- Write a Program to Print One Dimensional Array in Reverse Order
        Console.WriteLine("Input elements in array: ");
        int[] arr1D = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        Array.Reverse(arr1D);

        foreach (int x in arr1D)
            Console.Write(x+ " ");
        #endregion


    }
}
