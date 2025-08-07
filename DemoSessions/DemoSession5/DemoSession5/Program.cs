//using DemoSession5.Interface_Ex01;
using DemoSession5.Built_in_Interfaces;
using DemoSession5.Interface_Ex02;
using DemoSession5.Interface_Ex03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DemoSession5
{ 
    public class Programm
    {
        //Develop using interface
        static void Print10Nums(ISeries series)
        {
            if (series is null) return;
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{series.Current}\t");
                series.GetNext();
            }
            series.Reset();
            Console.WriteLine();
        }
        //static void Print10Nums(TypeB series)
        //{
        //    if (series is null) return;
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Console.Write($"{series.Current}\t");
        //        series.GetNext();
        //    }
        //    series.Reset();
        //    Console.WriteLine();
        //}
        public static void Main(string[] args)
        {
            #region Interface Example 01
            //IType reference;
            ////reference of type IType, contains garbage value
            ////this type can refer to an object of any "type Implementing IType Interface"

            ////reference = new IType(); //invalid, cant initiat a reference for interface
            //reference = new TypeA();
            //reference.MyProperty = 10;
            //reference.MyMethod();
            //reference.Print(); //Defualt Implement Method

            //TypeA typeA = new TypeA();
            //typeA.MyProperty = 20;
            //typeA.MyMethod();
            ////typeA.Print(); //Invalid, It implements IType but doesn't inherit from it 
            #endregion

            #region Interface Example 02
            //TypeA byTwo = new TypeA();
            //Print10Nums(byTwo);

            //TypeB byThree = new TypeB();
            //Print10Nums(byThree);
            #endregion

            #region Interface Example 03
            //Airplane airplane = new Airplane();
            //airplane.Speed = 190;
            ////airplane.Forward(); // invalid, Forward methods is private, which Forward method?

            //IFlyable flyable = airplane;
            //flyable.Forward(); //Valid

            //IMoveable moveable = airplane;
            //moveable.Forward(); // Vaild 
            #endregion

            #region Shallow vs Deep Copy
            //int[] arr = [2, 5, 7];
            //int[] arr2 = [5, 7, 9];
            //Console.WriteLine($"arr.GetHashCode(): {arr.GetHashCode()}");
            //Console.WriteLine($"arr2.GetHashCode(): {arr2.GetHashCode()}");

            //Console.WriteLine("------------------------------------------------");

            //arr2=arr;
            //Object [2, 5, 7] now has 2 references (arr, arr2)
            //Object [5, 7, 9] became unreachable

            // => Shallow Copy:
            //-> Effect: The outer object is copied, but inner elements are still references to the original.
            //-> Changes to inner elements affect both the original and the copy.

            //arr2[0] =100;
            //Console.WriteLine(arr[0]); // 100
            //Console.WriteLine($"arr.GetHashCode(): {arr.GetHashCode()}");
            //Console.WriteLine($"arr2.GetHashCode(): {arr2.GetHashCode()}");


            //Console.WriteLine("--------------------------------------");
            //arr2 = (int[]) arr.Clone();

            //Deep Copy
            //-> Effect: The copy is completely independent of the original.
            //-> Changes to any part of the deep copy do NOT affect the original.
            //Clone => will generate NEW object with New and Different Identity

            //            arr[0] = 100;
            //Console.WriteLine(arr2[0]); // 2

            //Console.WriteLine($"arr.GetHashCode(): {arr.GetHashCode()}");
            //Console.WriteLine($"arr2.GetHashCode(): {arr2.GetHashCode()}");

            #endregion

            #region IClonable
            //Employee emp1 = new Employee() { Id = 1, Name = "Khaled", Salary = 3_000 , Department = new Department() { Code=1001, Title= "Sales"} };
            //Employee emp2 = new Employee() { Id = 2, Name = "Omnia", Salary = 8_000 , Department = new Department() {Code = 1002, Title= "Marketing"}};

            //Console.WriteLine($"emp1.GetHashCode(): {emp1.GetHashCode()}");
            //Console.WriteLine($"emp2.GetHashCode(): {emp2.GetHashCode()}");

            //emp2 =(Employee) emp1.Clone(); // Deep Copy Using Clone Method
            // it should create new object with new and different identity
            // it also should have the same data as emp1



            //emp2 = new Employee(emp1); // Deep Copy Using Copy Constructor
            //if (emp2.Department is not null)
            //    emp2.Department.Title = "HR";

            //Console.WriteLine(emp1.Department.Title);


            //Console.WriteLine($"emp1.GetHashCode(): {emp1.GetHashCode()}");
            //Console.WriteLine($"emp2.GetHashCode(): {emp2.GetHashCode()}");

            //Console.WriteLine($"Employee 1: {emp1}");
            //Console.WriteLine($"Employee 2: {emp2}"); 
            #endregion

            #region IComparable and IComparer
            //int[] ints = [2, 6, 11, 7, 9, 5, 3, 0, 10];
            //Array.Sort(ints);

            ////foreach (int i in ints)
            ////    Console.Write(i+ "\t");

            //Employee[] employees =
            //{
            //    new Employee(){ Id=40, Name= "Omar", Salary= 6_000},
            //    new Employee(){ Id=10, Name= "Ahmed", Salary= 8_000},
            //    new Employee(){ Id=30, Name= "Nadia", Salary= 10_000},
            //    new Employee(){ Id=20, Name= "Omnia", Salary= 20_000},
            //};

            ////Array.Sort(employees); 
            //Array.Sort(employees, new EmployeeComparer());


            //foreach (Employee employee in employees)
            //    Console.WriteLine(employee);
            #endregion

            #region Sorting in Decending Order
            //int[] nums = [3, 9, 3, 8, 1, 0, 4, 7, 5, 6, 10];
            //Array.Sort(nums, new IntComparer());

            //foreach (int i in nums)
            //    Console.WriteLine(i); 
            #endregion

        }
    }
}