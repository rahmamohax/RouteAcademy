using System.Drawing;

namespace Assignment
{
    public class Prorgam
    {
        static void Point(ref Point point)
        {
            int x, y;
            do
            {
                Console.Write("Input X: ");  
            }
            while (!int.TryParse(Console.ReadLine(), out x));
            do
            {
                Console.Write("Input Y: ");
            }
            while (!int.TryParse(Console.ReadLine(), out y));
            point.X = x;
            point.Y = y;
            return;

        }

        static double CalcDistance(Point point1, Point point2)
        {
            double deltaX= point2.X = point1.X;
            double deltaY= point2.Y = point1.Y;
            return Math.Sqrt(Math.Pow(deltaX,2) + Math.Pow(deltaY, 2));
        }
        public static void Main(String[] args)
        {
            #region Define a struct "Person" with properties "Name" and "Age". Create an array of three "Person" objects and populate it with data. Then, write a C# program to display the details of all the persons in the array.

            //Person[] person = new Person[3]
            //{
            //    new Person { Name = "Alia", Age = 22 },
            //    new Person { Name = "Mariam", Age = 20 },
            //    new Person { Name = "Khalid", Age = 24 },
            //};

            //foreach (Person p in person) 
            //    Console.WriteLine(p);
            #endregion      #rq
            #region Create a struct called "Point" to represent a 2D point with properties "X" and "Y". Write a C# program that takes two points as input from the user and calculates the distance between them.
            //Point point01 = new Point(), point02= new Point();
            //Console.WriteLine("Enter Point 1's Data: ");
            //Point(ref point01);

            //Console.WriteLine("Enter Point 2's Data: ");
            //Point(ref point02);

            //Console.WriteLine("Distance between the two points is: " + CalcDistance(point01, point02)); 
            #endregion

            #region Create a struct called "Person" with properties "Name" and "Age". Write a C# program that takes details of 3 persons as input from the user and displays the name and age of the oldest person.


 
           #endregion
        }
    }
}