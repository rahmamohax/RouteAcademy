using System;
using System.Buffers.Text;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
class Person
{
    public string Name { get; set; }

    public Person(string name)
    {
        Name = name;
    }
}


class Program
{
    static void Main()
    {
        #region 1- Explain the difference between passing (Value type parameters) by value and by reference then write a suitable c# example.
        /* By Value: A copy of the value type is passed to the method
         * changes in method dosen't affect the original variable */

        /* By Ref: memory address of the value type is passed to the method 
         * changes in method affects the original variable */

        int num = 10;

        // Passing by value
        ModifyValue(num);
        Console.WriteLine($"After ModifyValue: {num}"); // Output: 10 (unchanged)

        // Passing by reference
        ModifyValueRef(ref num);
        Console.WriteLine($"After ModifyValueRef: {num}"); // Output: 20 (changed)


        static void ModifyValue(int value)
        {
            value = 20; // Only changes local copy
        }

        static void ModifyValueRef(ref int value)
        {
            value = 20; // Changes original variable
        }
        #endregion

        #region 2- Explain the difference between passing (Reference type parameters) by value and by reference then write a suitable c# example.
        /* By Value: A copy of the reference (pointer) is passed to the method
                - Can modify the object's state (properties/fields) but can't replace the entire object */

        /* By Ref:  The reference itself is passed by reference
                - Can both modify the object's state AND replace the entire object  */

        Person person = new Person("Alice");

        // Passing reference type by value
        ModifyPerson(person);
        Console.WriteLine($"After ModifyPerson: {person.Name}"); // Output: Bob

        // Passing reference type by reference
        ReplacePerson(ref person);
        Console.WriteLine($"After ReplacePerson: {person.Name}"); // Output: Charlie


        static void ModifyPerson(Person p)
        {
            // This affects the original object
            p.Name = "Bob";

            // This doesn't affect the caller's reference
            p = new Person("Dave");
        }

        static void ReplacePerson(ref Person p)
        {
            // This affects the caller's reference
            p = new Person("Charlie");
        }
        #endregion

        #region 3- Write a c# Function that accept 4 parameters from user and return result of summation and subtracting of two numbers
        static (double sum, double subtract) CalculateResults(double a, double b, double c, double d)
        {
            double sum = a + b;
            double subtract = c - d;
            return (sum, subtract);
        }

        #endregion

        #region 4- Write a program in C# Sharp to create a function to calculate the sum of the individual digits of a given number.

        Console.WriteLine("Input a number: ");
        int num1 = int.Parse(Console.ReadLine());

        int result = sum(num1);
        Console.WriteLine($"The sum of the digits of the number {num1} is: {result}");

        #endregion

        #region 5- Create a function named "IsPrime", which receives an integer number and retuns true if it is prime, or false if it is not
        Console.Write("Enter a number to check if it's prime: ");
        int numm = int.Parse(Console.ReadLine());
        Console.WriteLine($"{numm} is {(IsPrime(numm) ? "prime" : "not prime")}");
        #endregion

        #region 6- Create a function named MinMaxArray, to return the minimum and maximum values stored in an array, using reference parameters
        Console.WriteLine("input numbers in array");
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        MinMaxArray(numbers, out int min, out int max);
        Console.WriteLine($"Min: {min}, Max: {max}");
        #endregion

        #region 7- Create an iterative (non-recursive) function to calculate the factorial of the number specified as parameter
        static long facorial(int x)
        {
            long result = 1;
            if (x == 0 || x == 1)
                return 1;

            for (int i = x; i >= 1; i--)
                result *= i;

            return result;
        }
        long res = facorial(5);
        Console.WriteLine(res);
        #endregion



        #region 8- Create a function named "ChangeChar" to modify a letter in a certain position(0 based) of a string, replacing it with a different letter
        static void ChangeChar(ref string str, int position, char ch)
        {
            if (string.IsNullOrEmpty(str) || position < 0 || position > str.Length)
                return;

            var sb = new StringBuilder(str);
            sb[position] = ch;
            str= sb.ToString();
        }

        string str = "this is a test";
        Console.WriteLine(str);  //this is a test
        ChangeChar(ref str, 0, 'T');
        Console.WriteLine(str);  //This is a test
        #endregion
    }
    static int sum(int x)
        {
            int sum = 0;
            while (x > 0) {
                sum += x % 10;
                x /= 10;
            }
            return sum;
        }
    static bool IsPrime(int x)
    {
        if (x <= 1) return false;
        if (x == 2) return true;
        if (x % 2 == 0) return false;
        for (int i = 3; i < Math.Sqrt(x); i += 2)
        {
            if (x % i == 0) return false;
        }
        return true;
    }

    static void MinMaxArray(int[] array, out int min, out int max)
    {
        min = array.Min();
        max= array.Max();
    }
}