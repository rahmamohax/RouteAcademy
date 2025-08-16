using System.Collections.Generic;
using System.IO.Pipes;
using System.Text;

namespace Demo_1
{
    internal class Program
    {
        #region Methods

        public static void PrintShape(string pattern = "*", int count = 5)
        {
            for (int i = 1; i <= count; i++)
            {
                int.TryParse(Console.ReadLine(), out count);
                Console.WriteLine(pattern);
            }
        }

        public static void Swap(ref int X, ref int Y)
        {
            int temp = X;
            X = Y;
            Y = temp;
        }

        #endregion

        static void Main(string[] args)
        {
            #region Value Type
            //int x;
            //int y;

            //x = 5;
            //y = x;
            //Console.WriteLine(x);
            //Console.WriteLine(y);
            //Console.WriteLine("-------------------------------------------");
            //x++;
            //Console.WriteLine(x);


            #endregion

            #region Variable Decaration

            //int num;
            //string Class = "route";
            //num = 5;
            //Console.WriteLine(num);
            //Console.WriteLine(Class);

            #endregion

            #region MyRegion

            //declaration for variable from type int with name number
            //int number;
            //number = 10;
            //console.writeline(number);

            //string studentname = "amr ramadan";
            //console.writeline(studentname);

            #endregion

            #region Data Types

            #region Value Type Data Type
            //int x;
            //x = 10;
            //Console.WriteLine(x);

            //Int32 y = 20;
            //Console.WriteLine(y);

            //y = x;
            //Console.WriteLine(x);
            //Console.WriteLine(y);

            #endregion

            #region Reference Type
            //Point P1;

            //P1 = new Point()
            //;
            //Console.WriteLine(P1.x);
            //Console.WriteLine(P1.y);


            //Point P2 = new Point() { x = 10, y = 10 };
            //Console.WriteLine(P2.x);
            //Console.WriteLine(P2.y);

            //P2 = P1;
            //Console.WriteLine("After Assign P2 = P1");
            //Console.WriteLine(P1.x);
            //Console.WriteLine(P1.y);
            //Console.WriteLine(P2.x);
            //Console.WriteLine(P2.y);



            #endregion

            #endregion

            #region If Statment

            //Console.WriteLine("Enter The Number Of Month In 1st Quarter: ");
            //int num = int.Parse(Console.ReadLine());

            //if (num == 1)
            //{
            //    Console.WriteLine("It's January");
            //}
            //else if (num == 2)
            //{
            //    Console.WriteLine("It's Febreuary");
            //}

            //else if (num == 3)
            //{
            //    Console.WriteLine("It's March");
            //}
            //else
            //{
            //    Console.WriteLine("Unsupported Option");
            //}


            #endregion

            #region Switch Statment

            //Console.WriteLine("Enter The Number Of Month In 1st Quarter: ");
            //int num = int.Parse(Console.ReadLine());

            //switch (num)
            //{ 

            //    case 1:
            //        Console.WriteLine("It's January");
            //        break;
            //    case 2:
            //        Console.WriteLine("It's Febreuary");
            //        break;
            //    case 3:
            //        Console.WriteLine("It's March");    
            //        break;
            //    default:
            //        Console.WriteLine("Unsupported Option");
            //        break;

            //}

            #endregion

            #region Fraction And Discard

            //float myFloat = 10.123456789F;
            //Console.WriteLine(myFloat);

            //double myDouble = 10.123456789123456789;
            //Console.WriteLine(myDouble);

            //decimal MyDecimal = 10.123456789123456789123456789m;
            //Console.WriteLine(MyDecimal);

            //long number = 10_000_000_000;
            //Console.WriteLine($"{number:c}");

            #endregion

            #region Casting

            //int x = 10000000;
            //long y = x; //Implicit Casting
            //Console.WriteLine(y);

            //long A = 10000000000;
            //int B = (int) A; //Ecplicit Casting 
            //Console.WriteLine(B); //Due To Overflow

            //Protective Code
            #endregion

            #region Convert

            //Console.WriteLine("Hello please Enter Your Data");
            //Console.Write("Name : ");
            //string? name = Console.ReadLine();

            //Console.Write("Age: ");
            //int age = Convert.ToInt32( Console.ReadLine());

            //Console.Write("Salary : ");
            //decimal salary = Convert.ToDecimal( Console.ReadLine());


            //Console.Clear();

            //Console.WriteLine("======================================");
            //Console.WriteLine("Emlpyee Data");
            //Console.WriteLine("======================================");
            //Console.WriteLine($"Name is {name}");
            //Console.WriteLine($"Age is {age}");
            //Console.WriteLine($"Salary is {salary}");

            #endregion

            #region Parse

            //Console.WriteLine("Hello please Enter Your Data");
            //Console.Write("Name : ");
            //string? name = Console.ReadLine();

            //Console.Write("Age: ");
            //int age = int.Parse(Console.ReadLine() ?? "0");

            //Console.Write("Salary : ");
            //decimal salary = decimal.Parse(Console.ReadLine() ?? "0");


            //Console.Clear();

            //Console.WriteLine("======================================");
            //Console.WriteLine("Emlpyee Data");
            //Console.WriteLine("======================================");
            //Console.WriteLine($"Name is {name}");
            //Console.WriteLine($"Age is {age}");
            //Console.WriteLine($"Salary is {salary}");


            #endregion

            #region TryParse

            //string number02 = "Aliaa";
            //bool IsParsed = int.TryParse(number02, out int X02);
            //Console.WriteLine(IsParsed); //False
            //Console.WriteLine(X02); // 0


            //string number02 = "100";
            //bool IsParsed = int.TryParse(number02, out int X02);
            //Console.WriteLine(IsParsed); //True
            //Console.WriteLine(X02); // 1


            //=================================================================================



            //Console.WriteLine("Hello please Enter Your Data");
            //Console.Write("Name : ");
            //string? name = Console.ReadLine();

            //Console.Write("Age: ");
            ////int age = Convert.ToInt32(Console.ReadLine());
            //int.TryParse(Console.ReadLine(), out int age);

            //Console.Write("Salary : ");
            ////decimal salary = Convert.ToDecimal(Console.ReadLine());
            //decimal.TryParse(Console.ReadLine(), out decimal salary);


            //Console.Clear();

            //Console.WriteLine("======================================");
            //Console.WriteLine("Emlpyee Data");
            //Console.WriteLine("======================================");
            //Console.WriteLine($"Name is {name}");
            //Console.WriteLine($"Age is {age}");
            //Console.WriteLine($"Salary is {salary}");



            #endregion


            #region Unary Operators [++,--]

            //int x = 10;

            ////1.++
            ////Prefix [Increment and Then Print]
            //Console.WriteLine(++x);//11
            //Console.WriteLine(x);//11

            ////1.2 Postfix [Print and Then Increment]
            //Console.WriteLine(x++);//10
            //Console.WriteLine(x);//11

            ////2.--
            ////2.1 Prefix [Decrement and Then Print]
            //Console.WriteLine(--x);//9
            //Console.WriteLine(x);//9

            ////2.2 Postfix [Print and Then Decrement]
            //Console.WriteLine(x--); //10
            //Console.WriteLine(x);//9


            #endregion


            #region Arithmatic Operators [+ , - , * , / , %]

            //int num1 = 6 ,num2 = 2;
            //int Sum, sub, mul, div, mod;
            //Sum = num1 + num2; //8
            //sub = num1 - num2; //4
            //mul = num1 * num2; //12
            //div = num1 / num2; //3
            //mod = num1 % num2; //0

            //Console.WriteLine(Sum);
            //Console.WriteLine(sub);
            //Console.WriteLine(mul);
            //Console.WriteLine(div);
            //Console.WriteLine(mod);


            #endregion


            #region Assignment Operators [ = , += , -= , *= ,/= ,%=]

            //int x;
            //x = 4;
            //x += 2; //x = x + 2 
            //x -= 2; //x = x - 2
            //x *= 2; //x = x * 2
            //x /= 2; //x = x / 2
            //x %= 2; //x = x % 2

            #endregion


            #region Relational Operators [ == , != , < , > , <= , >=]

            //int x = 10, y = 10;
            //Console.WriteLine(x == y); //True
            //Console.WriteLine(x != y); //False
            //Console.WriteLine(x < y); //False
            //Console.WriteLine(x > y); //False
            //Console.WriteLine(x >= y); //True
            //Console.WriteLine(x <= y); //True

            #endregion


            #region Logical operators [! , && , ||]

            //Short Circit

            //Console.WriteLine(!true); //false
            //Console.WriteLine(false && true); //false
            /////true && true => ture
            /////true && fasle => false
            /////false && false => false
            /////false && true => false

            //Console.WriteLine(false || true ); //true
            /////true || true => true 
            /////ture || false => true 
            /////false || false => false
            /////fasle || true == true 




            #endregion


            #region BitWise Operators [& , | , ^ , ~ , << , >> ]

            ////Long Circuit
            ////works on binsry numbers

            //Console.WriteLine(false & true); //false
            /////true & true => ture
            /////true & fasle => false
            /////false & false => false
            /////false & true => false

            //Console.WriteLine(false | true); //true
            /////true | true => true 
            /////ture | false => true 
            /////false | false => false
            /////fasle | true == true 

            //int x = 5, y = 3;
            //Console.WriteLine(x ^ y); //XOR 
            ////0 ^ 0 => 0
            ////0 ^ 1 => 1
            ////1 ^ 1 => 0
            ////1 ^ 0 => 1

            //Console.WriteLine(~x); // complement

            //Console.WriteLine(x << 1 ); //shift left
            //Console.WriteLine(x >> 1); //shift right



            #endregion


            #region Ternary Operators [Conditional Operators] [?:] 

            //int x = 10, y = 5;

            ////Variable = condition ? true : false ;
            //string message = x > y ? "x > y" : "x < y";
            //Console.WriteLine(message);

            #endregion


            #region String Formatting

            //int x = 10 ; int y = 5;
            //int Result = x + y ;
            //string Message;

            ////1.String Interpolation

            //Message = $"Equation : {x} + {y} = {Result}";
            //Console.WriteLine(Message);

            ////2.String.Format Method

            //Message = string.Format("Equation : {0} + {1} = {2}", x, y, Result);
            //Console.WriteLine(Message);

            ////3.Composite Formatting
            //Console.WriteLine("Equation : {0} + {1} = {2}", x, y, Result);

            ////40.String Concatenation
            //Message = "Equation : " + x + " + " + y + " = " + Result;
            //Console.WriteLine(Message);

            #endregion


            #region Coditonal Statment

            #region If Else

            //Console.WriteLine("Please Enter A month Number Existed in 1st Quarter");
            //int.TryParse(Console.ReadLine(), out int monthNimber);

            //if (monthNimber == 1)
            //{
            //    Console.WriteLine("Hello Jan");
            //}
            //else if (monthNimber == 2)
            //{
            //    Console.WriteLine("Hello Feb");

            //}
            //else if (monthNimber == 3)
            //{
            //    Console.WriteLine("Hello Mar");
            //}
            //else
            //{
            //    Console.WriteLine("The Entered Month Nimber Is Not Valid Month At First Quarter");
            //}

            #endregion

            #region Switch

            //Console.WriteLine("Please Enter A month Number Existed in 1st Quarter");
            //int.TryParse(Console.ReadLine(), out int monthNimber);


            ////Jump Table Will Be Generated By Compiler Compilation Time
            //switch(monthNimber)
            //{
            //    case 1:
            //        Console.WriteLine("Hello jan");
            //        break;
            //    case 2:
            //        Console.WriteLine("Hello Feb");
            //        break;
            //    case 3:
            //        Console.WriteLine("Hello Mar");
            //        break;
            //    default:
            //        Console.WriteLine("The Entered Month Nimber Is Not Valid Month At First Quarter");
            //            break;
            //}

            #endregion

            #endregion


            #region Evalution Of Switch In C#

            #region [Pattern Matching - Case Guards]

            //object number = 5.6; //Boxing


            ////Pattern Matching
            //switch (number)
            //{
            //    case int value: // Unboxing
            //        Console.WriteLine("Integer");
            //        break;
            //    case float value:
            //        Console.WriteLine("Float");
            //        break;
            //    case double value:
            //        Console.WriteLine("Double");
            //        break;
            //    default: 
            //        Console.WriteLine("No Matching");
            //        break;
            //}

            ///============================================================================ 

            //Case Guards (when)
            //switch (number)
            //{
            //    case int value when value < 10: // Unboxing
            //        Console.WriteLine("Integer Is Less Than 10");
            //        break;
            //    case int value when value > 10: // Unboxing
            //        Console.WriteLine("Integer Is Greater Than 10");
            //        break;
            //    case float value:
            //        Console.WriteLine("Float");
            //        break;
            //    case double value when value > 5.5 && value < 10.10:
            //        Console.WriteLine("Double");
            //        break;
            //    default:
            //        Console.WriteLine("No Matching");
            //        break;
            //}
            #endregion

            #endregion


            #region Loop Statment

            #region For - Foreach Loop

            //int[] number = { 1, 2, 3, 4, 5 };

            //for (int i = 0; i < number.Length; i++)
            //{
            //    Console.WriteLine(number[i]);
            //}

            //foreach (int i in number)
            //{
            //    Console.WriteLine(i);
            //}

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(i);
            //}

            #endregion

            #region While - DO While Loop

            //=====================================Do While Loop========================================= 

            //bool isParsed;
            //int number;

            //do
            //{

            //Console.WriteLine("Please Enter An Even Number: ");
            //isParsed = int.TryParse(Console.ReadLine(),out number);

            //} while (!isParsed || number % 2 == 1  );

            //Console.WriteLine($"{number} is An Even Number");


            //========================================While===============================================

            //Console.WriteLine("Enter A number: ");
            //bool isParsed = int.TryParse(Console.ReadLine(), out int number);

            //if(isParsed)
            //{

            //    while (number <= 10) 
            //    {
            //        Console.WriteLine(number);
            //        number++;
            //    }

            //}



            #endregion

            #endregion

            #region String (System.String)
            ///Immutable => Can't be changed once they're created
            ///Any modification on the string creates a new one, leaving the original unchanged
            ///Best for small text operations or when text changes rarely.
            /// Array of Characters
            /// string and String are the same (alias vs. class name).


            #region Example 01
            //string name;

            //name = new string("Route");
            //Console.WriteLine($"Name {name}"); //   Route
            //Console.WriteLine($"Hashcode Name: {name.GetHashCode()}");

            //string name02 = "Route";
            /////CLR checks if string exists in string bool
            /////if exists => assignes the address to the exsisted string  (reuse memory location)
            /////if not => adds new string in string pool

            //Console.WriteLine($"Name {name02}");
            //Console.WriteLine($"Hashcode Name: {name02.GetHashCode()}"); // same hash code 

            #endregion

            #region Example 02
            //string name01 = "Amr";
            //string name02 = "May";

            //Console.WriteLine($"Name {name01}");
            //Console.WriteLine($"Hashcode Name {name01.GetHashCode()}");
            //Console.WriteLine($"Name {name02}");
            //Console.WriteLine($"Hashcode Name {name02.GetHashCode()}");

            //name02 = name01; // May is unreachable object
            //Console.WriteLine("After Assign name02 = name01 ");
            //Console.WriteLine($"Name {name02}");
            //Console.WriteLine($"Hashcode Name {name02.GetHashCode()}");

            //name01 = "Omar";
            //Console.WriteLine("After changing name01");
            //Console.WriteLine($"Name {name01}");
            //Console.WriteLine($"Hashcode Name {name01.GetHashCode()}");

            #endregion

            #region Example 03

            //string message = "Hello";
            //Console.WriteLine(message);
            //Console.WriteLine(message.GetHashCode());

            //message += "Route";
            //Console.WriteLine("After Changing in Message");
            //Console.WriteLine(message);
            //Console.WriteLine(message.GetHashCode());

            #endregion

            #endregion

            #region String Method
            //string message = "  Hello Route  ";
            //Console.WriteLine(message.Length);
            //Console.WriteLine(message.ToUpper());
            //Console.WriteLine(message.ToLower());
            //Console.WriteLine(message.Trim());
            //Console.WriteLine(message.TrimStart());
            //Console.WriteLine(message.TrimEnd());
            //Console.WriteLine(message.Substring(0, 5));
            //Console.WriteLine(message.Replace('e', 'm'));
            //Console.WriteLine(message.Contains('o'));

            #endregion

            #region Stringbuilder (System.Text)
            ///Mutable string type → allows modifications without creating new objects.
            ///Efficient for frequent modifications (append, insert, remove).
            ///Much faster than string when doing lots of concatenations in loops.Mutable string type → allows modifications without creating new objects.
            ///Efficient for frequent modifications (append, insert, remove).
            ///Much faster than string when doing lots of concatenations in loops.

            //StringBuilder message = new StringBuilder("Hello");

            //Console.WriteLine(message); // Hello
            //Console.WriteLine(message.GetHashCode());
            //message.Clear();
            //message.Append("Route");
            //Console.WriteLine("After Changing Message");
            //Console.WriteLine(message); //Route
            //Console.WriteLine(message.GetHashCode()); //same hashcode

            //message.Append(" Academy");
            //Console.WriteLine(message); // Route Academy
            //Console.WriteLine(message.GetHashCode()); //same hashcode
            #endregion

            #region Array

            //int[] numbers; // Declare for reference from type array
            //numbers = new int[3];
            //numbers[0] = 1;
            //numbers[1] = 2;
            //numbers[2] = 3;

            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    Console.WriteLine(numbers[i]);
            //}

            //Console.WriteLine(numbers[0]);
            //Console.WriteLine(numbers[1]);
            //Console.WriteLine(numbers[2]);


            #region 1D Array

            #region Example 01

            //int[] numbers;
            //numbers = new int[3];//12 byte

            ////Console.WriteLine(numbers[0]);
            ////Console.WriteLine(numbers[1]);
            ////Console.WriteLine(numbers[2]);

            //numbers[0] = 1;
            //numbers[1] = 2;
            //numbers[2] = 3;

            ////Console.WriteLine(numbers[0]);
            ////Console.WriteLine(numbers[1]);
            ////Console.WriteLine(numbers[2]);

            //Console.WriteLine($"Lenght Of Array {numbers.Length}");
            //Console.WriteLine($"Rank Of Array {numbers.Rank}");

            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    Console.WriteLine(numbers[i]);
            //}



            #endregion

            #endregion

            #region 2D Array

            //int[,] Marks = new int[2, 5];  //{ {100,90,30,50,40 }, 
            //                               //{20,10,60,100,55 } };

            //Console.WriteLine($"Lenght Of Array {Marks.Length}");
            //Console.WriteLine($"Rows Of Array {Marks.GetLength(0)}");
            //Console.WriteLine($"Columns Of Array {Marks.GetLength(1)}");
            //Console.WriteLine($"Rank Of Array {Marks.Rank}");

            //for (int i = 0; i < Marks.GetLength(0); i++)
            //{
            //    Console.WriteLine($"The Grades Of Student Number {i+1}");
            //    for (int j = 0; j < Marks.GetLength(1); /*j++*/)
            //    {
            //        Console.Write($"Subject Number {j+1}");
            //        //Marks[i,j] =int.Parse(Console.ReadLine()); 
            //        bool Flag = int.TryParse(Console.ReadLine(), out Marks[i,j]);

            //        if(Flag)
            //            j++;
            //    }
            //    Console.WriteLine("///////////////////////////////////////////");
            //}

            //for (int i = 0; i < Marks.GetLength(0); i++)
            //{
            //    Console.WriteLine($"The Grades Of Student Number {i + 1}");
            //    for (int j = 0; j < Marks.GetLength(1); j++)
            //    {
            //        Console.WriteLine($"Subject Number {j + 1} ={Marks[i,j]} ");

            //    }
            //}

            #endregion

            #region Jagged Array

            //int[][] JaggeDArray = new int[3][];

            //JaggeDArray[0] = new int[3] {1,2,3};
            //JaggeDArray[1] = new int[2] {4,5};
            //JaggeDArray[2] = new int[1] {6};

            //for (int i = 0; i < JaggeDArray.Length; i++)
            //{
            //    for (int j = 0; j < JaggeDArray[i].Length; j++) 
            //    {

            //        Console.WriteLine(JaggeDArray[i][j]);

            //    }
            //}

            #endregion

            #endregion


            #region Functions

            //PrintShape("*_*",10); //Passing By Order
            //PrintShape(count: 10, pattern: "*_-"); //Passing By Name
            //PrintShape();//Using Defult

            #region Vlaue Type Parameters

            #region Passing By Value
            //int A = 10, B = 5;
            //Console.WriteLine($"A = {A}");
            //Console.WriteLine($"B = {B}");

            //Swap(A, B);
            //Console.WriteLine("After Swapping");
            //Console.WriteLine($"A = {A}");
            //Console.WriteLine($"B = {B}"); 
            #endregion

            #region Passing By Reference

            //int A = 10, B = 5;
            //Console.WriteLine($"A = {A}");
            //Console.WriteLine($"B = {B}");

            //Swap(ref A, ref B); //Passing By Reference
            //Console.WriteLine("After Swapping");
            //Console.WriteLine($"A = {A}");
            //Console.WriteLine($"B = {B}");



            #endregion
            #endregion

            #endregion
        }

        #region Comments

        //1- single line comment
        //this function is used for adding two int number

        //2- two multiline comments
        /*this function
         * is used for
         * adding two numbers
         */

        //3-XML comments

        #endregion
    }

}
