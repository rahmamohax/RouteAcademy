using DemoSession01LINQ;
using LINQSession1.Data;
using System.Collections;
using static DemoSession01LINQ.ListGenerator;

namespace LINQSession1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Extention Method
            //int number = 12345;
            //int reverse = number.Reverse();
            //Console.WriteLine(reverse);
            #endregion

            #region Anonymous Type
            //var employee1 = new { Id = 5, Name = "Ali", Salary = 10000 };
            //Console.WriteLine(employee1.GetType().Name); //<>f__AnonymousType0`3

            ////ReadOnly Data
            ////employee.Name = "Maram"; //Invalid [Immutable Object] can't be changed

            //var employee2 = employee1 with { Name = "Ahmed" };
            //Console.WriteLine(employee2.GetType().Name); //<>f__AnonymousType0`3

            //Same Anonymous Type as long as:
            //1. Same Properties [Case Sensitive]
            //2. Same Properties Order
            #endregion

            #region LINQ Syntax
            //List<int> Numbers = new List<int>(10) { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            #region 1. Method Syntax [Fluent]
            //1.1 Call as Static Method [Class -Member Methods]
            //var EvenNums = Enumerable.Where(Numbers, i => i % 2 == 0);

            //1.2 Call as Object Member Methods [Extentions]
            //EvenNums = Numbers.Where(i => i % 2 == 0);

            //foreach (var item in EvenNums)
            //    Console.Write(item + " "); 
            #endregion

            #region 2. Query Syntax
            // Must Start with 'from' and Must end with 'select' || 'group by'

            //var EvenNums = from n in Numbers
            //               where n % 2 == 0
            //               select n;

            //foreach (var item in EvenNums) Console.Write(item + " ");

            #endregion

            #endregion

            #region Execution Ways
            //List<int> Numbers = new List<int>(10) { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //var evenNums = Numbers.Where(i => i %2 == 0); //Deferred Execution
            ////var evenNums = Numbers.Where(i => i %2 == 0).ToList(); //Immidiate Execution
            //Numbers.AddRange([11, 12, 13, 14, 15]);

            //foreach (var item in evenNums)
            //    Console.Write(item + " "); //2 4 6 8 10 12 14
            #endregion

            #region Setup Data
            //Product? product = ProductList?[1];
            //Console.WriteLine(product);

            //Customer? customer = CustomerList?[0];
            //Console.WriteLine(customer);
            #endregion

            #region Filteration (Where, OfType)
            #region Where
            //var result = ProductList?.Where(x => x.UnitPrice>0 && x.UnitPrice < 20m);

            //result = from p in ProductList
            //         where p.UnitPrice > 0 && p.UnitPrice < 20m
            //         select p;


            //filter first 10 products to includes names with less than 10 characters
            //var filter = ProductList?.Where((p, i) => i <= 10 && p.ProductName?.Length <= 10);

            //foreach (var item in filter)
            //    Console.WriteLine(item); 
            #endregion

            #region OfType
            //var selectType = ProductList?.OfType<Product02>()
            //    .Where(p => p.UnitPrice > 10m);

            //foreach (var item in selectType)
            //    Console.WriteLine(item);

            //ArrayList fruits = new ArrayList()
            //{
            //    "Apple",
            //    "Banana",
            //    null,
            //    10,
            //    10.20,
            //    "Mango",
            //    "LemoN"
            //};

            //var result = fruits.OfType<string>().Where(s => s.Contains('n')); //Banana
            // Mango
            //var result = fruits.OfType<string>().Where(s => s.Contains('n', StringComparison.OrdinalIgnoreCase)); //Banana
            //                                                                                                      //Mango
            //                                                                                                      //LemoN

            //foreach (var item in result)
            //    Console.WriteLine(item);
            #endregion
            #endregion

            #region Projection Operatiors [Select, Select Many, Zip]
            #region Select
            //var names = ProductList?.Select(p => p.ProductName);

            //names = from p in ProductList
            //        select p.ProductName;

            //var result = ProductList?.Select(p => new { p.ProductID, p.ProductName });

            //result = from p in ProductList
            //         select new
            //         {
            //             p.ProductID,
            //             p.ProductName,
            //         };


            //var result = ProductList?.Where(p => p.UnitPrice > 0)
            //    .Select(p => new
            //    {
            //        Id = p.ProductID,
            //        Name = p.ProductName,
            //        OldPrice = p.UnitPrice,
            //        NewPrice = p.UnitPrice - (p.UnitPrice * 0.1m)
            //    });

            //result = from p in ProductList
            //         where p.UnitPrice > 0
            //         select new
            //         {
            //             Id = p.ProductID,
            //             Name = p.ProductName,
            //             OldPrice = p.UnitPrice,
            //             NewPrice = p.UnitPrice - (p.UnitPrice * 0.1m)
            //         };


            //var result = ProductList?.Where(p => p.UnitsInStock > 0)
            //    .Select((p, i) => new
            //    {
            //        SerialNum = i + 1,
            //        Name = p.ProductName
            //    }); 
            #endregion

            #region Select Many
            //var result = CustomerList?.SelectMany(c => c.Orders);

            //result = from c in CustomerList
            //         from o in c.Orders
            //         select o;


            //var result = CustomerList?.SelectMany(c => c.Orders, (cust, ordr) => (cust.CustomerName, ordr.OrderID));

            //result = from c in CustomerList
            //         from o in c.Orders
            //         select (c.CustomerName, o.OrderID);


            //var result = CustomerList?.SelectMany((c, custIdx) => c.Orders
            //    .Select((o, ordIdx) => new {
            //        CustomerIdx = custIdx,
            //        CustomerName = c.CustomerName,
            //        OrderIdx = ordIdx +1 ,
            //        OrderId = o.OrderID
            //    }));


            //foreach (var item in result) Console.WriteLine(item); 
            #endregion

            #region ZIP

            //List<int> nums = [1, 2, 3, 4, 5, 6, 7];
            //char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F' };
            //string[] words = { "first", "second", "third", "fourth" };

            ////var res = nums.Zip(letters);
            ////var res = nums.Zip(letters, (n,c) => $"Num {n} is zipped w letter {c}");
            //var res = nums.Zip(letters, words);

            //foreach (var item in res)
            //    Console.WriteLine(item); 

            #endregion
            #endregion

            #region Sorting [OrderBy, OrderByDesc, ThenBy, ThenByDesc, Reverse]
            //var res =CustomerList?.OrderBy(c => c.CustomerName);

            //res = from c in CustomerList
            //      orderby c.CustomerName
            //      select c;


            //var res = ProductList?.OrderBy(p => p.UnitsInStock).ThenByDescending(p => p.UnitPrice);

            //res = from p in ProductList
            //      orderby p.UnitsInStock, p.UnitPrice descending
            //      select p;


            //var res = ProductList?.Where(p => p.ProductName?.Length < 10)
            //    .Select(p => p.ProductName).Reverse();


            var res = ProductList?.Where(p => p.ProductName?.Length < 10)
                .Select(p => p.ProductName)
                .OrderBy(s=> s?.Length);
 
            foreach (var item in res)
                Console.WriteLine(item);

            #endregion
        }
    }
}