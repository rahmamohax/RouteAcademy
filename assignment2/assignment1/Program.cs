// See https://aka.ms/new-console-template for more information
using System.ComponentModel;

class Person
{
    public string Name;
}
internal class Program
{
    private static void Main(string[] args)
    {
        #region 1. Write a program that allows the user to enter a number then print it.

        //Console.Write("Input a number: ");
        //int x = int.Parse(Console.ReadLine());
        //Console.WriteLine(x);

        #endregion


        #region 2. Write C# program that converts a string to an integer, but the string contains non-numeric characters. And mention what will happen 
        //string input = "123abc";

        //    int result = Convert.ToInt32(input);
        //    Console.WriteLine("Conversion to int: " + result);

        //// will give an error becouse convertion can't accure
        #endregion

        #region 3. Write C# program that Perform a simple arithmetic operation with floating-point numbers And mention what will happen

        //    var x = 35.5;
        //    var y = 15.2;
        //    var add = x + y;
        //Console.WriteLine("Arthimetic result:" + add);

        #endregion


        #region 4. Write C# program that Extract a substring from a given string.
        //string text = "Hello, World!";
        //Console.WriteLine("Substring: " + text.Substring(7, 5));
        #endregion


        #region 5. Write C# program that Assigning one value type variable to another and modifying the value of one variable and mention what will happen
        //int a = 10;
        //int b = a;
        //b = 20;

        //Console.WriteLine("a: " + a); // Still 10
        //Console.WriteLine("b: " + b); // 20
        #endregion


        #region 6. Write C# program that Assigning one reference type variable to another and modifying the object through one variable and mention what will happen
        Person p1 = new Person();
        p1.Name = "Ali";
        Person p2 = p1;

        p2.Name = "Khaled";

        Console.WriteLine(p1.Name); //Khaled
        Console.WriteLine(p2.Name); //Khaled

        #endregion


        #region 7. Write C# program that take two string variables and print them as one variable 
        string firstName = "Rahma";
        string lastName = "Mohamed";

        string fullName = firstName + " " + lastName;
        Console.WriteLine("Full Name: " + fullName);
        #endregion


        #region Question 8
        // b) A value 1 will be assigned to d.
        #endregion

        #region Question 9
        Console.WriteLine(13 / 2 + " " + 13 % 2);
        // 6 1
        #endregion

        #region Question 10
        int num = 1, z = 5;

        if (!(num <= 0))
            Console.WriteLine(++num + z++ + " " + ++z);
        else
            Console.WriteLine(--num + z-- + " " + --z);

        // 7 7
        #endregion

    }
}
