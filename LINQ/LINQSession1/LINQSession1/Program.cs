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


            //var res = ProductList?.Where(p => p.ProductName?.Length < 10)
            //    .Select(p => p.ProductName)
            //    .OrderBy(s=> s?.Length);

            //foreach (var item in res)
            //    Console.WriteLine(item);

            #endregion

            #region Element Operators [First, Last, ElementAt, Single]
            //var result = ProductList?.First(); // can throw exception
            //result = ProductList?.Last();
            //Console.WriteLine(result);

            //List<Product> list = new List<Product>();
            ////var first= list.First();
            //var first = list.FirstOrDefault(new Product()); // more protective
            //Console.WriteLine(first); //null: will throw exception

            //var result = ProductList?.ElementAt(1); //second element
            //var result = ProductList?.ElementAt(new Index(1, true)); //First element from end [1-Based Indexing]
            //result = ProductList?.ElementAt(^1); //First element from end [1-Based Indexing]

            //var result = ProductList?.ElementAtOrDefault(100); //more protective
            //Console.WriteLine(result);

            //var res = ProductList?.SingleOrDefault( p=> p.ProductID==1);
            //Console.WriteLine(res);


            //Hybrid Syntax
            //var result = (from p in ProductList
            //             where p.UnitPrice > 20
            //             select p).FirstOrDefault();

            //Console.WriteLine(result);

            #endregion

            #region Aggregate Operators [Count, Sum, Avg]
            //var result = ProductList.Count(); //LINQ Count
            //result = ProductList.Count; // List Property 

            //var result = ProductList?.Where(p=> p.UnitsInStock == 0).Count();
            //result = ProductList?.Count(p => p.UnitsInStock == 0);
            //Console.WriteLine(result);

            //var sum = ProductList.Sum(x => x.UnitPrice);
            //var avg = ProductList.Average(x => x.UnitPrice);
            //Console.WriteLine(sum);
            //Console.WriteLine(avg);

            //var max = ProductList?.Max(p => p.ProductName);

            //var res = (from p in ProductList
            //          where p.ProductName == max
            //          select p).FirstOrDefault();
            //Console.WriteLine(res);

            #region Aggregate
            //Will be Usful when Using APIs
            //string[] words = ["Hello", "From", "the", "Other", "Sideeeeee"];

            //var res = words.Aggregate((st1, st2) => $"{st1} {st2}");
            ////st1= 'Hello', st2= 'From'
            ////st1 = 'Hello From', st2 = 'the'
            ////st1 = 'Hello From the' , st2 = 'Other' ....

            //res = words.Aggregate("Adel Once Said:", (st1, st2) => $"{st1} {st2}");
            //Console.WriteLine(res);

            #endregion

            #endregion

            #region Casting Operators
            //var res= ProductList?.Where(p => p.UnitPrice > 0).ToList(); //Casting to List

            //Dictionary<long, Product> products = ProductList.Where(p => p.UnitsInStock ==0).ToDictionary(p => p.ProductID, p => p);
            //foreach (var item in products)
            //    Console.WriteLine(item.Key +" " + item.Value);

            #endregion

            #region Generation Operators
            //Enumerable.Range(1, 100); //1..100
            //Enumerable.Repeat(2, 50);

            //var prods = Enumerable.Repeat(new Product() { Category = "Meat" }, 5); //5 products with category Meat

            #endregion

            #region Set Operators [Union, Intersect, Except]

            //var products1 = new List<Product>()
            //{
            //    new Product {ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18.00M, UnitsInStock = 100},
            //    new Product {ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18.00M, UnitsInStock = 100},
            //    new Product{ ProductID = 2, ProductName = "Chang", Category = "Beverages", UnitPrice = 19.0000M, UnitsInStock = 17 },
            //    new Product{ ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10.0000M, UnitsInStock = 13 },
            //    new Product{ ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", Category = "Condiments", UnitPrice = 22.0000M, UnitsInStock = 53 },
            //}; 
            //var products2 = new List<Product>()
            //{
            //    new Product{ ProductID = 2, ProductName = "Chang", Category = "Beverages", UnitPrice = 19.0000M, UnitsInStock = 17 },
            //    new Product{ ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", Category = "Condiments", UnitPrice = 22.0000M, UnitsInStock = 53 },
            //    new Product{ ProductID = 5, ProductName = "Chef Anton's Gumbo Mix", Category = "Condiments",UnitPrice = 21.3500M, UnitsInStock = 0 },
            //};

            //var union = products1.Union(products2); // 1, 2, 3, 4, 5
            //union = products1.UnionBy(products2, keySelector: p=> p.ProductID);  //compares with ID


            //var intersect = products1.Intersect(products2); // 2, 4

            //var except = products1.Except(products2); //1, 5 //product1 ايه الي موجود في 
            //product2 مش موجود في 

            //var dis = products1.Distinct();
            //dis = products1.DistinctBy(x => x.ProductID);

            //foreach (var item in dis) 
            //    Console.WriteLine(item);
            #endregion

            #region Quantifier Operators - Return Boolean

            //Console.WriteLine(ProductList?.Any()); //true
            //Console.WriteLine(ProductList?.Any(p => p.UnitsInStock == 0)); //true

            //Console.WriteLine(ProductList?.All(p => p.UnitsInStock == 0)); //false

            //var products1 = new List<Product>()
            //{
            //    new Product {ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18.00M, UnitsInStock = 100},
            //    new Product{ ProductID = 2, ProductName = "Chang", Category = "Beverages", UnitPrice = 19.0000M, UnitsInStock = 17 },
            //    new Product{ ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10.0000M, UnitsInStock = 13 },
            //    new Product{ ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", Category = "Condiments", UnitPrice = 22.0000M, UnitsInStock = 53 },
            //};

            //Console.WriteLine(ProductList?.Contains(products1[0])); //true

            #endregion

            #region Let - Into

            //var res = from p in ProductList
            //          where p.UnitPrice * .9m > 10
            //          select new
            //          {
            //              p.ProductName,
            //              Price = p.UnitPrice * .9m
            //          };

            //using let
            //var res = from p in ProductList
            //          let Price= p.UnitPrice * 0.9m
            //          where Price < 10
            //          select new
            //          {
            //              p.ProductName,
            //              Price
            //          };


            //using into
            //var res = from p in ProductList
            //      select p.UnitPrice * 0.9m
            //      into Price
            //      where Price < 10
            //      select Price;

            //foreach (var item in res)
            //{
            //    Console.WriteLine(item); 
            //}

            #endregion

            #region Partitioning Operators

            //var result = ProductList.Where(p => p.UnitPrice > 0).Take(5);
            //var result = ProductList.Where(p => p.UnitPrice > 0).TakeLast(5);

            //var result = ProductList.Where(p => p.UnitPrice > 0).Skip(5); // skips first 5 and returns everything else
            //var result = ProductList.Where(p => p.UnitPrice > 0).Skip(5).Take(5);

            //int[] ints = [5, 4, 7, 8, 9, 6, 3, 1, 2, 3];

            //var res = ints.TakeWhile((n, i) => n > i); //5 4 7 8 9 6
            //var res = ints.Where((n, i) => n > i);   //5 4 7 8 9 6



            int[] ints = [5, 4, 7, 8, 9, 6, 3, 1, 2, 3];
            var res = ints.Chunk(3);

            foreach (var item in res)
                {
                foreach (var i in item)
                {
                    Console.Write(i + " ");   
                }
                Console.WriteLine();
            }


            #endregion


        }
    }
}