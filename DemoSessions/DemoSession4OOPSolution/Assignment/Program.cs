namespace Assignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Project 1
            //Define 3D Point Class and the basic Constructors (use chaining in constructors).

            //Override the ToString Function to produce this output:

            //Read from the User the Coordinates for 2 points P1, P2(Check the input using try Pares, Parse, Convert).
            //Point3D P1 = new Point3D();
            //Point3D P2 = new Point3D();
            //string[] input;
            //int x, y, z;
            //bool isValid= false;
            //do
            //{
            //    Console.WriteLine("Input Coordinates for P1: (x,y,z) ");
            //    input = Console.ReadLine().Split(",");
            //     if (input.Length ==3 &&
            //        int.TryParse(input[0], out x) &&
            //        int.TryParse(input[1], out y) &&
            //        int.TryParse(input[2], out z))
            //    {
            //        P1 = new(x, y, z);
            //        isValid = true;
            //    }
            //    else Console.WriteLine("Invalid Input, Please enter 3 Numbers saperated with comma");
            //}while (!isValid);


            //do
            //{
            //    Console.WriteLine("Input Coordinates for P2: (x,y,z) ");
            //    input = Console.ReadLine().Split(",");
            //    if (input.Length == 3 &&
            //       int.TryParse(input[0], out x) &&
            //       int.TryParse(input[1], out y) &&
            //       int.TryParse(input[2], out z))
            //    {
            //        P2 = new(x, y, z);
            //        isValid = true;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Invalid Input, Please enter 3 Numbers saperated with comma");
            //        isValid = false;
            //    }
            //    }while (!isValid);

            ////Try to use ==> If(P1 == P2)   Does it work properly? 
            //if (P1 == P2)
            //    Console.WriteLine("P1 = P2");
            //else Console.WriteLine("P1 != P2");  //NO, its not working correctly


            #endregion

            #region Project 2
            //Define Class Maths that has four methods: Add, Subtract, Multiply, and Divide, each of them takes two parameters. Call each method in Main ().

            //Modify the program so that you do not have to create an instance of class to call the four methods.

            //Console.WriteLine($"Addition {Maths.Add(4, 67)}");
            //Console.WriteLine($"Subrtaction {Maths.Subtract(46.3, 7.7)}");
            //Console.WriteLine($"Multiplication {Maths.Multiply(4, 7)}");
            //Console.WriteLine($"Division {Maths.Divide(7, 3)}");

            #endregion

            #region Project 3
            //Define Class Duration To include Three Attributes Hours, Minutes and Seconds.

            //Override All System.Object Members (ToString, Equals,GetHasCode) .

            #region Define All Required Constructors to Produce this output:
            Duration D1 = new Duration(1, 10, 15);
            //Console.WriteLine("D1: " + D1);
            ////Output: Hours: 1, Minutes: 10, Seconds: 15

            D1 = new Duration(3600);
            //Console.WriteLine("D1: " + D1);
            ////Output: Hours: 1, Minutes: 0, Seconds: 0

            Duration D2 = new Duration(7800);
            //Console.WriteLine("D1: " + D2);
            ////Output: Hours: 2, Minutes: 10, Seconds: 0

            Duration D3 = new Duration(666);
            //Console.WriteLine("D1: " + D3);
            ////Output: Minutes: 11, Seconds: 6

            #endregion

            #region Implement All required Operators overloading to enable this Code:
            D3 = D1 + D2;
            Console.WriteLine("D3 = D1 + D2: " + D3);

            D3 = D1 + 7800;
            Console.WriteLine("D3 = D1 + 7800 " + D3);

            D3 = 666 + D3;
            Console.WriteLine("D3 = 666 + D3; " + D3);

            D3 = ++D1;//(Increase One Minute)
            Console.WriteLine("D3 = ++D1: " + D3);

            D3 = --D2;  //(Decrease One Minute)
            Console.WriteLine("D3 = --D2: " + D3);

            D1 = D1 - D2;
            Console.WriteLine("D3 = D1 - D2: " + D3);

            if (D1 > D2) Console.WriteLine("D1 > D2");
            else Console.WriteLine("D2 > D1");
            //If(D1 <= D2)
            //If(D1)
            //DateTime Obj = (DateTime)D1

            #endregion
            #endregion
        }
    }
}