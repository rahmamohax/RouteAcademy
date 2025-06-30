using System;
using System.Linq;
using System.Numerics;

internal class Program
{
    private static void Main(string[] args){
        #region 1- Write a program that takes a number from the user then print yes if that number can be divided by 3 and 4 otherwise print no.
        int x = int.Parse(Console.ReadLine());

        if (x % 3 == 0 && x % 4 == 0)
            Console.WriteLine("Yes");
        else
            Console.WriteLine("No");
        #endregion

        #region 2- Write a program that allows the user to insert an integer then print negative if it is negative number otherwise print positive.
        int num = int.Parse(Console.ReadLine());

        if (num >= 0)
            Console.WriteLine("Positive");
        else
            Console.WriteLine("Negitive");
        #endregion

        #region 3- Write a program that takes 3 integers from the user then prints the max element and the min element.
        string[] input = Console.ReadLine().Split(',', ' ');
        int x1 = int.Parse(input[0]);
        int x2 = int.Parse(input[1]);
        int x3 = int.Parse(input[2]);

        int max = Math.Max(x1, Math.Max(x2, x3));
        int min = Math.Min(x1, Math.Min(x2, x3));

        Console.WriteLine("Max element: " + max);
        Console.WriteLine("min element: " + min);
        #endregion

        #region 4- Write a program that allows the user to insert an integer number then check If a number is even or odd.
        int xx = int.Parse(Console.ReadLine());

        if (xx % 2 == 0)
            Console.WriteLine("even");
        else Console.WriteLine("odd");
        #endregion

        #region 5- Write a program that takes character from the user then if it is a vowel chars (a,e,I,o,u) then print (vowel) otherwise print (consonant).
        char c = char.ToLower(Console.ReadKey().KeyChar);
        Console.WriteLine();

        if ("aeiou".Contains(c))
            Console.WriteLine("vowel");
        else Console.WriteLine("Consonant");

        #endregion


    }
}