using DemoSession6.Abstraction;
using DemoSession6.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSession6
{
    ///Abstraction
    ///Goal => Hide complex implementation details of an object
    ///allows developers designing systems that seperate what object does from how it does it

    /// Adstract Modifier => Indicates a missing/incomplete implementaion
    /// can be used with classes, methods, properties, indexers, events
    /// 


    ///             Abstract Class                              vs                              Interface
    /// A base class that gives you some ready-made                         A contract/blueprint — says “anyone who signs this
    ///     code and says “subclasses, fill in the                               must write all the code themselves.”
    ///         blanks for the rest.
    /// Can have implemented methods (with logic)	                                     	No implementation
    /// A class can inherit only ONE abstract class	                             A class can implement MANY interfaces

    ///          Partially Built Logic                                       List of rules you must follow to build any Class!


    /// When to Use Abstract Class?
    /// - when you need to share code among classes
    ///- when you have methods that hold a default behavior, yet can be modified
    ///- when you need to include fields(attributes)
    ///- when yyou need to provide a base class
    class Program
    {
        static void ProcessShape(Shape shape)
        {
            Console.WriteLine($"Area of Shape: {shape.CalcArea():f2}");
            Console.WriteLine($"Perimeter of Shape: {shape.Perimeter:f2}");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            #region Abstraction
            //Shape shape = new Shape(); //Invalid, can't create an instanse from an abstract class
            //But can create a reference from Abstract Class to an object
            //object's class must inherit and implement the abstract class (duh!!)

            //Shape shape = new Rectangle(); //Valid

            //Rectangle rectangle = new Rectangle(10,20);
            //ProcessShape(rectangle);
            ////Console.WriteLine("Area: "+ rectangle.CalcArea());
            ////Console.WriteLine("Perimeter: "+ rectangle.Perimeter);

            //Square square = new Square(side:10);
            //ProcessShape(square);
            ////Console.WriteLine("Area: " + square.CalcArea());
            ////Console.WriteLine("Perimeter: " + square.Perimeter);

            //Circle circle = new Circle(5);
            //ProcessShape(circle);
            ////Console.WriteLine($"Area: {circle.CalcArea():F2}");
            ////Console.WriteLine($"Perimeter: {circle.Perimeter:F2}"); 
            #endregion

            Utility utility = new Utility(3, 6);
            Console.WriteLine(utility.MetertoCm(3.3));

        }

    }
}