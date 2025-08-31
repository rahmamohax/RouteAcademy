using Session3.BuiltinDelegate;
using Session3.Example_1;
using Session3.Example_2;
using Session3.Example_3;
using Session3.FPP;

namespace Session3
{
    class Program
    {
        //Delegates: a type that represents refreneces to methods
        public delegate int StringFuncDelegate(string? s);
        //new Delegate (class)
        //Reference from this delegate can refer to:
        //one or more function (pointer)
        //fuction must match the signature of delegate (parameter list - return type)

        public static void Main(string[] args)
        {
            #region Example 1
            //Step 01. Decleare Reference from delegate
            //Step 02. Initialize reference => point to a function

            //StringFuncDelegate stringFunc = new StringFuncDelegate(StringFunction.GetCountOfUpperChar);
            //StringFuncDelegate stringFunc = StringFunction.GetCountOfUpperChar; //Syntax Sugar
            //Func<string, int> stringFunc;

            //stringFunc = StringFunction.GetCountOfLowerChar; // Add New Reference for function

            //stringFunc += StringFunction.GetCountOfUpperChar;

            ////Step 03.Use Delegate Reference to[Call[Invoke] Method]

            //int? res = stringFunc?.Invoke("RoUtE");
            //if (stringFunc is not null)
            //{
            //    int res = stringFunc("RoUtE"); //Syntax Sugar
            //    Console.WriteLine(res);
            //}
            #endregion

            #region Example 2
            //int[] ints = { 3, 7, 6, 2, 4, 5, 0, 8, 1, 9 };
            ////StrategyDelegate<int, int, bool> sorting = SortingStrategies.SortAsc;
            //Func<int, int, bool> sorting = SortingStrategies.SortAsc;

            //SortingAlgorithms<int>.BubbleSort(ints, sorting); //In Asc

            //Console.WriteLine("Ascending");
            //foreach (var item in ints)
            //    Console.Write(item + " ");


            //Console.WriteLine("\n\nDescending");
            //SortingAlgorithms<int>.BubbleSort(ints, SortingStrategies.SortDesc); //In Desc
            //foreach (var item in ints)
            //    Console.Write(item + " ");
            #endregion

            #region Example 2 Generic
            //string[] names = ["Omar", "Khaled", "Mohamed", "Amr"];

            ////StrategyDelegate<string, string, bool>? strategy = SortingStrategies.SortDesc;
            //Func<string, string, bool>? strategy = SortingStrategies.SortDesc;
            //SortingAlgorithms<string>.BubbleSort(names, strategy);
            //foreach (var item in names)
            //    Console.Write(item + " ");
            #endregion

            #region Example 3

            //List<int> numbers = Enumerable.Range(1, 100).ToList();
            //foreach (var item in numbers) Console.Write(item + " ");
            //Console.WriteLine("\n");

            ////FilterNumbersDelegate<int> filter = FiltersOfList.CheckOdd;
            //Predicate<int> filter = FiltersOfList.CheckOdd;
            //List<int> Odd = FilteredLists.FilterElements(numbers, filter);
            //foreach (var item in Odd) Console.Write(item + " ");

            //Console.WriteLine("\n");
            //filter += FiltersOfList.CheckEven;
            //List<int> Even = FilteredLists.FilterElements(numbers, filter);
            //foreach (var item in Even) Console.Write(item + " ");

            //Console.WriteLine("\n");
            //List<string> names = ["Ahmed", "Aya", "khaled", "Rawan", "Amr", "Manal"];
            //List<string> lessThan4 = FilteredLists.FilterElements(names, FiltersOfList.CheckMoreThan4);
            //foreach (var item in lessThan4) Console.Write(item + " ");

            #endregion

            #region Built-In Delegates [Acton, Func<T, TResult>, Predicate<T>]
            ///Acton: 
            ///1. Non Generic => Takes 0 Parameters and must be void
            ///2. Generic => Takes 1-16 Parameters and must be void
            ///Func<T, TResult> => Takes 0-16 Parameters of type T and return TResult
            ///Predicate<T> =>  Takes 1 Parameter of type T and return bool

            //Predicate<int> predicate = TestBuiltinDelegates.CheckPositive;
            //bool flag = predicate.Invoke(10);
            //Console.WriteLine(flag);

            //Func<int, string> cast = TestBuiltinDelegates.Casting;
            //string num = cast.Invoke(10);
            //Console.WriteLine(num); // 10


            //Action action1 = TestBuiltinDelegates.Print;
            //action1.Invoke(); //Hello Route
            //action1(); //Hello Route


            //Action<string> action2 = TestBuiltinDelegates.Print;
            //action2.Invoke("Rahma"); //Hello Rahma
            //action2("Rahma"); //Hello Rahma
            #endregion

            #region Anonymous Method

            //Predicate<int> predicate =delegate (int c) { return c > 0;}; //Anonymous Method
            //bool flag = predicate.Invoke(10);
            //Console.WriteLine(flag);

            //Func<int, string> cast = delegate (int c) { return c.ToString(); }; //Anonymous Method
            //string num = cast.Invoke(10);
            //Console.WriteLine(num); // 10


            //Action action1 = delegate { Console.WriteLine("Hello Route"); }; //Anonymous Method
            //action1.Invoke(); //Hello Route
            //action1(); //Hello Route


            //Action<string> action2 = delegate (string name) { Console.WriteLine("Hello " + name); }; //Anonymous Method
            //action2.Invoke("Rahma"); //Hello Rahma
            //action2("Rahma"); //Hello Rahma
            #endregion

            #region Lambda Expression

            //Predicate<int> predicate =  c => c > 0;  //Lambda Expression
            //bool flag = predicate.Invoke(10);
            //Console.WriteLine(flag);

            //Func<int, string> cast =   c => c.ToString(); //Lambda Expression
            //string num = cast.Invoke(10);
            //Console.WriteLine(num); // 10


            //Action action1 = () => Console.WriteLine("Hello Route"); //Lambda Expression
            //action1.Invoke(); //Hello Route
            //action1(); //Hello Route


            //Action<string> action2 =  name => Console.WriteLine("Hello " + name); //Lambda Expression
            //action2.Invoke("Rahma"); //Hello Rahma
            //action2("Rahma"); //Hello Rahma
            #endregion

            #region List Methods [Continued]
            //List<int> ints = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            //bool flag = ints.Exists(s => s == 10);
            //Console.WriteLine(flag); //True

            //int e = ints.Find(s => s % 2 == 0);
            //Console.WriteLine(e); //2

            //ints.ForEach(s => Console.Write(s + " ")); // 1 2 3 4 5 6 7 8 9 10

            //Console.WriteLine("\n");
            //int removes= ints.RemoveAll(x => x % 3 == 0);
            //Console.WriteLine(removes); // 3
            //ints.ForEach(s => Console.Write(s + " ")); // 1 2 4 5 7 8 10


            //List<Employee> employees = new List<Employee>()
            //{
            //    new Employee() {Id = 1, Name= "Ali" , Age =18},
            //    new Employee() {Id = 2, Name= "Amr" , Age =22},
            //    new Employee() {Id = 3, Name= "Khaled" , Age =28},
            //};

            //foreach (var item in employees) Console.WriteLine(item + " ");
            //// 1: Ali: 18
            //// 2: Amr: 22
            //// 3: Khaled: 28

            //employees.ForEach(e => e.Id += 100);
            //Console.WriteLine("\n");
            //foreach (var item in employees) Console.WriteLine(item + " ");
            //// 101: Ali: 18
            //// 102: Amr: 22
            //// 103: Khaled: 28

            #endregion

            #region Functional Programing Paradigm
            //FunctionReturnDelegate.DelegateAction(); //no nothing
            Action action= FunctionReturnDelegate.DelegateAction();
            action(); //calling returned function
            //OR
            FunctionReturnDelegate.DelegateAction().Invoke();
            FunctionReturnDelegate.DelegateAction()();


            Predicate<int> predicate= FunctionReturnDelegate.DelegatePredicate();
            Console.WriteLine(predicate.Invoke(-10)); //False
            Console.WriteLine(predicate(-15)); //False
            //OR
            Console.WriteLine(FunctionReturnDelegate.DelegatePredicate().Invoke(10)); //True
            Console.WriteLine(FunctionReturnDelegate.DelegatePredicate()(10)); //True


            Func<char[], string> func= FunctionReturnDelegate.DelegateFunc();
            string res = func.Invoke([ 'a', 'b', 'c' ]);
            Console.WriteLine(res);
            #endregion
        }
    }
}