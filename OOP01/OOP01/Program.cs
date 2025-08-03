//See https://aka.ms/new-console-template for more information
using System.Reflection.Emit;
using System;
using OOP01;
using System.Threading.Channels;

class Program
{
     enum WeekDays
    {
        Monday=0, 
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday, 
        Sunday
    }

    enum Season
    {
        spring,
        summer,
        autumn,
        winter
    }

    [Flags]
    enum Permissions : byte
    {
        Read =1,
        Write =2,
        Delete=4,
        Execute=8
    }

    enum Colors
    {
        Red, Blue, Green
    }

    static void Main() {
        #region 1. Create an enum called "WeekDays" with the days of the week (Monday to Sunday) as its members. Then, write a C# program that prints out all the days of the week using this enum.
        //Console.WriteLine("Days of the Week:");
        //foreach (WeekDays d in Enum.GetValues(typeof(WeekDays)))
        //    Console.WriteLine(d);
        #endregion

        #region 2. Define a struct "Person" with properties "Name" and "Age". Create an array of three "Person" objects and populate it with data. Then, write a C# program to display the details of all the persons in the array.
        //Person[] person = new Person[3];
        //person[0] = new Person("Ali", 21);
        //person[1] = new Person("Khalid", 27);
        //person[2] = new Person("Mariam", 20);

        //for (int i = 0; i < person.Length; i++) 
        //    Console.WriteLine($"Person {i}'s  Name: {person[i].Name}, Age: {person[i].Age}");
        #endregion

        #region 3. Create an enum called "Season" with the four seasons (Spring, Summer, Autumn, Winter) as its members. Write a C# program that takes a season name as input from the user and displays the corresponding month range for that season. Note range for seasons ( spring march to may , summer june to august , autumn September to November , winter December to February)
        //Console.Write("Input Season Name (Spring, Summer, Autumn, Winter): ");
        //string input = Console.ReadLine();

        //bool isvalid = Enum.TryParse(input, true, out Season season);

        //if (isvalid)
        //{
        //    var result = season switch
        //    {
        //        Season.spring => "March to May",
        //        Season.summer => "June to Augest",
        //        Season.autumn => "Septemper to November",
        //        Season.winter => "December to Fabuary"
        //    };
        //    Console.WriteLine(result);
        //}
        //else Console.WriteLine("Invalid Season");
        #endregion

        #region 4- Assign the following Permissions (Read, write, Delete, Execute) in a form of Enum.
        //Create Variable from previous Enum to Add and Remove Permission from variable, check if specific Permission is existed inside variable

        //initial permisions
        //Permissions user = Permissions.Read | Permissions.Write;

        //// Check if User Has Delete, if not assign it to user
        //bool hasDelete= (user & Permissions.Delete) == Permissions.Delete;
        //if (hasDelete) Console.WriteLine("User Has Delete permission");
        //else
        //{
        //    user ^= Permissions.Delete;
        //    Console.WriteLine("Delete Permision is Assigned to User");
        //    Console.WriteLine("User permissions: " + user);
        //}
        #endregion

        #region 5.Create an enum called "Colors" with the basic colors(Red, Green, Blue) as its members.Write a C# program that takes a color name as input from the user and displays a message indicating whether the input color is a primary color or not.
        //Console.WriteLine("Input a Color");
        //string input = Console.ReadLine();

        //bool isPrimary = Enum.TryParse(input, true, out Colors color);
        //if (isPrimary)
        //    Console.WriteLine($"{color} is a primary color");
        //else Console.WriteLine($"{input} is not a primary color");
        #endregion

        #region 6. Create a struct called "Point" to represent a 2D point with properties "X" and "Y". Write a C# program that takes two points as input from the user and calculates the distance between them.
        //Console.Write("Input coordinates for Point 1 (x,y): ");
        //if (!TryReadPoint(out Point p1)) return;

        //Console.Write("Input coordinates for Point 2 (x,y): ");
        //if (!TryReadPoint(out Point p2)) return;

        //Console.WriteLine($"Diatance Between the 2 Points is: {CalcDis(p1,p2):F2}");

        //static bool TryReadPoint(out Point p) {
        //    p = default;
        //    string input = Console.ReadLine();
        //    var parts= input.Split(",").Select(s => s.Trim()).ToArray();

        //    if (parts.Length != 2 ||
        //    !double.TryParse(parts[0], out double x) ||
        //    !double.TryParse(parts[1], out double y)) {
        //        Console.WriteLine("Invalid Input");
        //        return false;
        //    }
        //    p = new Point(x, y);
        //    return true;
        //}


        //static double CalcDis(Point p1, Point p2)
        //{
        //    double deltaX = p2.X - p1.X;
        //    double deltaY = p2.Y - p1.Y;
        //    return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        //}
        #endregion

        #region 7. Create a struct called "Person" with properties "Name" and "Age". Write a C# program that takes details of 3 persons as input from the user and displays the name and age of the oldest person.
        //Person[] people = new Person[3];
        //for (int i = 0; i < people.Length; i++) {
        //    Console.Write($"Enter person {i}'s Name: ");
        //    people[i].Name=  Console.ReadLine();

        //    Console.Write($"Enter person {i}'s Age: ");
            
        //   if(int.TryParse(Console.ReadLine(), out int age))
        //        people[i].Age= age;
        //}
        //Person oldest = people[0];
        //foreach (Person person in people)
        //{
        //    if (person.Age > oldest.Age) 
        //        oldest = person;
        //}

        //Console.WriteLine($"The Oldest of all People is {oldest.Name} with {oldest.Age} years old");
        #endregion


    }

}