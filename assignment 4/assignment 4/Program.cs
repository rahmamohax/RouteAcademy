using System;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    private static void Main(string[] args)
    {
        #region  6 - Write a program that allows the user to insert an integer then print all numbers between 1 to that number.
        int x;

        if (int.TryParse(Console.ReadLine(), out x))
        {
            for (int i = 1; i < x; i++)
                Console.Write(i + ", ");
            Console.Write(x);
        }
        #endregion

        #region 7- Write a program that allows the user to insert an integer then print a multiplication table up to 12.
        int num;

        if (int.TryParse(Console.ReadLine(), out num))
            for (int i = 1; i <= 12; i++)
                Console.Write(i * num + " ");
        #endregion

        #region 8- Write a program that allows to user to insert number then print all even numbers between 1 to this number
        int even;

        if (int.TryParse(Console.ReadLine(), out even))
            for (int i = 1; i <= even; i++)
                if (i % 2 == 0)
                    Console.Write(i + " ");
        #endregion

        #region 9- Write a program that takes two integers then prints the power.
        string input = Console.ReadLine();
        string[] numbers = input.Split(" ");

        if (numbers.Length == 2 &&
                int.TryParse(numbers[0], out int baseNum) &&
                int.TryParse(numbers[1], out int exp))
        {
            double result = Math.Pow(baseNum, exp);
            Console.WriteLine(result);

        }
        #endregion

        #region 10- Write a program to enter marks of five subjects and calculate total, average and percentage.
        Console.Write("Enter Marks of five subjects: ");
        string input2 = Console.ReadLine();
        string[] marks = input2.Split(" ");
        int total = 0;
        int[] arr = new int[5];

        try
        {
            if (marks.Length == 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    arr[i] = int.Parse(marks[i]);
                    total += arr[i];
                }

                double avg = total / 5.0;
                double perc = (total / 500.0) * 100;

                Console.WriteLine($"Total marks = {total}");
                Console.WriteLine($"Average Marks = {(avg)}");
                Console.WriteLine($"Percentage = {(perc)}");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid Input Type");
        }


        #endregion

        #region 11- Write a program to input the month number and print the number of days in that month.
        string msg;
        int month;
        if (int.TryParse(Console.ReadLine(), out month))
        {
            msg = month switch
            {
                1 => "Day in month: 31",
                2 => "Day in month: 28",
                3 => "Day in month: 31",
                4 => "Day in month: 30",
                5 => "Day in month: 31",
                6 => "Day in month: 30",
                7 => "Day in month: 31",
                8 => "Day in month: 31",
                9 => "Day in month: 30",
                10 => "Day in month: 31",
                11 => "Day in month: 30",
                12 => "Day in month: 31",
            };
            Console.WriteLine(msg);
        }
        #endregion

        #region 12- Write a program to create a Simple Calculator.
        Console.WriteLine("1. Addition (+)");
        Console.WriteLine("2. Subtraction (-)");
        Console.WriteLine("3. Multiplication (*)");
        Console.WriteLine("4. Division (/)");

        Console.Write("Enter Operation's Number: ");
        int op = int.Parse(Console.ReadLine());

        Console.Write("Enter 2 Numbers: ");
        string input1 = Console.ReadLine();
        string[] nums = input1.Split(" ");

        if (nums.Length == 2 &&
            int.TryParse(nums[0], out int num1) &&
            int.TryParse(nums[1], out int num2))
        {
            double result = 0;
            switch (op)
            {
                case 1:
                    result = num1 + num2;
                    Console.WriteLine($"Result: {num1} + {num2} = {result}");
                    break;

                case 2:
                    result = num1 - num2;
                    Console.WriteLine($"Result: {num1} - {num2} = {result}");
                    break;

                case 3:
                    result = num1 * num2;
                    Console.WriteLine($"Result: {num1} * {num2} = {result}");
                    break;

                case 4:
                    result = num1 / num2;
                    Console.WriteLine($"Result: {num1} / {num2} = {result}");

                    break;

                _:
                    Console.WriteLine("Invalid Option");
            }
        }
        #endregion

        #region 13- Write a program to allow the user to enter a string and print the REVERSE of it.
        Console.Write("enter a string: ");
        string st = Console.ReadLine();

        char[] arrchar = st.ToCharArray();
        Array.Reverse(arrchar);
        string reverse = new string(arrchar);
        Console.WriteLine($"Reversed String: {reverse}");
        #endregion

        #region 14- Write a program to allow the user to enter int and print the REVERSED of it.

        Console.Write("Enter an integer: ");
        int number = int.Parse(Console.ReadLine());

        int reversed = 0;
        while (number != 0)
        {
            int digit = number % 10;
            reversed = reversed * 10 + digit;
            number /= 10;
        }
        Console.WriteLine($"Reversed number: {reversed}");
        #endregion

        #region 15- Write a program in C# Sharp to find prime numbers within a range of numbers.
        static bool isPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            for (int i = 3; i <= Math.Sqrt(number); i += 2)
                if (((number % i) == 0)) return false;
            return true;
        }
        Console.Write("Input starting number of range: ");
        int start = int.Parse(Console.ReadLine());
        Console.Write("Input ending number of range: ");
        int end = int.Parse(Console.ReadLine());
        Console.WriteLine("The prime number between 1 and 50 are :");

        for (int i = start; i < end; i++)
        {
            if (isPrime(i))
                Console.Write(i + " ");
        }
        #endregion


        #region 18 - Within a company, the efficiency of workers is evaluated based on the duration required to complete a specific task

        Console.Write("Enter the time taken to complete the task (in hours): ");
        double time = double.Parse(Console.ReadLine());

        if (time >= 2 && time <= 3) Console.WriteLine("Highly efficient");
        else if (time > 3 && time <= 4) Console.WriteLine("Increase your speed");
        else if (time > 4 && time <= 5) Console.WriteLine("Training required to improve speed");
        else if (time > 5) Console.WriteLine("You are required to leave the company");

        #endregion


    }
}