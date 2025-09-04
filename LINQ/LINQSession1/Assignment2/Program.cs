using DemoSession01LINQ;
using LINQSession1.Data;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;
using System.Threading;
using static DemoSession01LINQ.ListGenerator;
using static System.Net.Mime.MediaTypeNames;
namespace Assignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region LINQ - Element Operators

            #region 1. Get first Product out of Stock 
            //Console.WriteLine(ProductList?.FirstOrDefault(p => p.UnitsInStock ==0));
            #endregion

            #region 2. Return the first product whose Price > 1000, unless there is no match, in which case null is returned.

            //var result = ProductList?.FirstOrDefault(p => p.UnitPrice > 1000);
            //if (result is not null)
            //    Console.WriteLine(result);
            //else Console.WriteLine("No Match Found");
            #endregion
            #region 3. Retrieve the second number greater than 5 

            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var result = Arr.Where(x => x > 5).ElementAt(1);
            //Console.WriteLine(result); // 8
            #endregion


            #endregion

            #region LINQ - Aggregate Operators

            #region 1. Uses Count to get the number of odd numbers in the array
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //Console.WriteLine(Arr.Count(x => x %2 ==1));
            #endregion

            #region 2. Return a list of customers and how many orders each has.
            //var numOfOrders = CustomerList?.Select(c => new {c.CustomerName, OrderCount= c.Orders?.Count()});
            //foreach (var item in numOfOrders)
            //    Console.WriteLine(item);

            #endregion

            #region 3. Return a list of categories and how many products each has
            //var prods = ProductList?.GroupBy(p => p.Category)
            //    .Select(c => new { Category = c.Key, ProductsCount = c.Count() });

            //foreach (var item in prods)
            //    Console.WriteLine(item);
            #endregion

            #region 4. Get the total of the numbers in an array.
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //Console.WriteLine(Arr.Sum());
            #endregion

            #region dictionary_english.txt
            //string[] words = File.ReadAllLines("dictionary_english.txt");

            #region 5. Get the total number of characters of all words in dictionary_english.txt
            //Console.WriteLine(words.Sum(c => c.Length));
            #endregion

            #region 6. Get the length of the shortest word in dictionary_english.txt 
            //Console.WriteLine(words.Min(c => c.Length));
            #endregion

            #region 7. Get the length of the longest word in dictionary_english.txt
            //Console.WriteLine(words.Max(c => c.Length));
            #endregion

            #region 8. Get the average length of the words in dictionary_english.txt
            //Console.WriteLine(words.Average(c => c.Length));
            #endregion
            #endregion

            #region 9. Get the total units in stock for each product category.
            //var total = ProductList?.GroupBy(p => p.Category)
            //    .Select(c => new {c.Key, TotalUnitsInStock = c.Sum( x=> x.UnitsInStock)});

            //foreach (var item in total)
            //    Console.WriteLine(item);
            #endregion

            #region 10. Get the cheapest price among each category's products

            //var cheapest = ProductList?.GroupBy(c => c.Category)
            //    .Select(p => new
            //    {
            //        Category = p.Key,                   
            //        MinPrice = p.Min(x => x.UnitPrice)
            //    });

            //foreach (var item in cheapest)
            //    Console.WriteLine(item);
            #endregion

            #region 11. Get the products with the cheapest price in each category (Use Let)

            //var cheapest = from p in ProductList
            //               group p by p.Category into c
            //               let minPrice = c.Min( x=> x.UnitPrice)
            //               select new { c.Key ,minPrice };

            //foreach (var item in cheapest)
            //    Console.WriteLine(item);
            #endregion

            #region 12. Get the most expensive price among each category's products.
            //var max = ProductList?.GroupBy(c => c.Category)
            //    .Select(p => new { 
            //        p.Key, 
            //        MaxPrice = p.Max(x => x.UnitPrice)
            //    });

            //foreach (var item in max)
            //    Console.WriteLine(item);
            #endregion

            #region 13. Get the products with the most expensive price in each category.
            //var res = from p in ProductList
            //          group p by p.Category into c
            //          let max = c.Max(x => x.UnitPrice)
            //          select new
            //          {
            //              Category = c.Key,
            //              Products = c.Where(p => p.UnitPrice == max)
            //          };

            //foreach (var item in res){
            //    Console.WriteLine(item.Category);
            //    foreach (var prod in item.Products)
            //        Console.WriteLine(prod);
            //}
            #endregion

            #region 14. Get the average price of each category's products.
            //var avg = ProductList?.GroupBy(p => p.Category)
            //    .Select(c => new
            //    {
            //        c.Key,
            //        AvgPrice = c.Average(p => p.UnitPrice)
            //    });

            //foreach (var item in avg)
            //    Console.WriteLine(item);

            #endregion
            #endregion

            #region LINQ - Set Operators
            #region 1. Find the unique Category names from Product List
            //var res = ProductList?.Select(c => c.Category).Distinct();
            //foreach (var item in res)
            //    Console.WriteLine(item);

            #endregion

            #region 2. Produce a Sequence containing the unique first letter from both product and customer names.
            //var res = ProductList?.Select(p => p.ProductName[0]).Union(CustomerList?.Select(c => c.CustomerName[0]));

            //foreach (var item in res)
            //    Console.WriteLine(item);

            #endregion

            #region 3. Create one sequence that contains the common first letter from both product and customer names.

            //var prod = ProductList?.Select(x => x.ProductName[0]);
            //var cust = CustomerList?.Select(x => x.CustomerName[0]);
            //var seq = prod?.Intersect(cust);

            //foreach (var item in seq)
            //    Console.WriteLine(item);
            #endregion

            #region 4. Create one sequence that contains the first letters of product names that are not also first letters of customer names.

            //var prod = ProductList?.Select(x => x.ProductName[0]);
            //var cust = CustomerList?.Select(x => x.CustomerName[0]);
            //var seq = prod?.Except(cust);

            //foreach (var item in seq)
            //    Console.WriteLine(item);
            #endregion

            #region 5. Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates

            //var prod = ProductList?.Select(x => x.ProductName.Substring( x.ProductName.Length-3));
            //var cust = CustomerList?.Select(x => x.CustomerName.Substring(x.CustomerName.Length - 3));
            //var seq = prod?.Concat(cust);

            //foreach (var item in seq)
            //    Console.WriteLine(item);
            #endregion

            #endregion

            #region LINQ - Quantifiers
            //string[] words = File.ReadAllLines("dictionary_english.txt");

            #region 1. Determine if any of the words in dictionary_english.txt contain the substring 'ei'.
            //Console.WriteLine(words.Any(x => x.Contains("ei"))); //true
            #endregion

            #region 2. Return a grouped a list of products only for categories that have at least one product that is out of stock.

            //var res= ProductList?.GroupBy(c => c.Category).Where( p => p.Any(c => c.UnitsInStock == 0))
            //    .Select(c => new {
            //        Category = c.Key,
            //        Product = c.Where(p => p.UnitsInStock == 0)
            //    });
            //foreach (var item in res)
            //{
            //    Console.WriteLine("Category: " + item.Category);
            //    foreach (var x in item.Product)
            //    {
            //        Console.WriteLine(x);
            //    }
            //    Console.WriteLine();
            //}
            #endregion
            #region 3. Return a grouped a list of products only for categories that have all of their products in stock.

            //var res = ProductList?.GroupBy(c => c.Category).Where(p => p.All(c => c.UnitsInStock > 0));
            //foreach (var item in res)
            //{
            //    Console.WriteLine("Category: " + item.Key);
            //    foreach (var x in item)
            //    {
            //        Console.WriteLine(x);
            //    }
            //    Console.WriteLine();
            //}

            #endregion
            #endregion

            #region LINQ – Grouping Operators

            #region 1. Use group by to partition a list of numbers by their remainder when divided by 5
            //List<int> numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            //var groups = numbers.GroupBy(n => n % 5);

            //foreach (var g in groups)            
            //    Console.WriteLine($"Remainder {g.Key}: {string.Join(",", g)}");
            #endregion

            #region 2. Uses group by to partition a list of words by their first letter.
            //List<string> words = File.ReadAllLines("dictionary_english.txt").ToList();
            //var res= words.GroupBy(n => n[0]).ToList();

            //foreach (var item in res)
            //{
            //    Console.WriteLine(item.Key);
            //    foreach (var i in item)
            //        Console.WriteLine(i);
            //    Console.WriteLine();
            //}
            #endregion

            #region Use Group By with a custom comparer that matches words that are consists of the same Characters Together

            string[] Arr = { "from", "salt", "earn", " last", "near", "form" };

            var anagrams = Arr.GroupBy(w => new string(w.OrderBy(c => c).ToArray()));

            foreach (var g in anagrams)           
                Console.WriteLine($"{string.Join(",", g)}");
           
            #endregion
            #endregion
        }
    }
}