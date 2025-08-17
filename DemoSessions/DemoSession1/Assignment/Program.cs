using System.ComponentModel;

namespace Assignment
{
    enum WeekDays
    {
        Monday, Tuesday, Wednesday, Friday, Saturday, Sunday
    }

    enum Season
    {
        Spring=1,spring=1 ,summer =2, Summer =2, Autumn=3 , aurumn=3, Winter =4, winter =4
    }
    [Flags]
    enum Permission : byte
    {
        Read=1, Write=2, Delete=4, Execute=8
    }

    enum Colors
    {
        Red =1,
        Green=1,
        Blue = 1,
        Yellow,
        Orange,
        Purple
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            #region Create an Enum called "WeekDays" with the days of the week (Monday to Sunday) as its members. Then, write a C# program that prints out all the days of the week using this Enum.

            //foreach (WeekDays day in Enum.GetValues(typeof(WeekDays)))
            //    Console.WriteLine(day);

            #endregion
            #region Create an Enum called "Seas on" with the four seasons (Spring, Summer, Autumn, Winter) as its members. Write a C# program that takes a season name as input from the user and displays the corresponding month range for that season. Note range for seasons ( spring march to may , summer June to August , autumn September to November , winter December to February)
            //Season season;
            //do
            //{
            //    Console.Write("Type a Season: "); 

            //} while (!Enum.TryParse<Season>(Console.ReadLine(), out season));

            //string month = season switch
            //{
            //    Season.Spring => "March to May",
            //    Season.Summer => "June to August",
            //    Season.Autumn => "September to November",
            //    Season.Winter => "December to February",
            //    _ => "Unknown"
            //};

            //Console.WriteLine($"Season : {season} => {month}");




            #endregion
            #region Assign the following Permissions (Read, write, Delete, Execute) in a form of Enum, Create Variable from previous Enum to Add and Remove Permission from variable, check if specific Permission existed inside variable

            //Permission permission = Permission.Read | Permission.Delete;
            //Console.WriteLine(permission);


            //if ((permission & Permission.Read) == Permission.Read)
            //    Console.WriteLine("User Has Read Permission");
            //else Console.WriteLine("User dont have Read Permission");
            #endregion
            #region Create an Enum called "Colors" with the basic colors (Red, Green, Blue) as its members. Write a C# program that takes a color name as input from the user and displays a message indicating whether the input color is a primary color or not.
            Colors colors;
            do
            {
                Console.Write("Enter a Color: ");
            }
            while (!Enum.TryParse<Colors>(Console.ReadLine(), out colors));

            if ((int)colors == 1)
                Console.WriteLine("This Color is a Primary Color");
            else Console.WriteLine("This Color is not a Primary Color");
            #endregion

        }
    }
}