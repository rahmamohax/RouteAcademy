using DemoSession01LINQ;
using LINQSession1.Data;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;
using static DemoSession01LINQ.ListGenerator;
namespace Assignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region LINQ - Restriction Operators

            #region 1. Get first Product out of Stock 

            //var result = ProductList?.First(p => p.UnitsInStock == 0);
            //Console.WriteLine(result);

            #endregion

            #region 2. Find all products that are in stock and cost more than 3.00 per unit.
            //var res = ProductList?.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3m);
            //foreach (var item in res)
            //    Console.WriteLine(item);

            #endregion

            #region 3. Returns digits whose name is shorter than their value.
            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            //var res = Arr.Where((c, i) => c.Length < i);

            //foreach (var item in res)
            //    Console.WriteLine(item);
            #endregion

            #endregion

            #region LINQ - Ordering Operators
            #region 1. Sort a list of products by name
            //var res = ProductList?.OrderBy(p => p.ProductName);

            //foreach (var item in res)
            //    Console.WriteLine(item);

            #endregion

            #region 2. Uses a custom comparer to do a case-insensitive sort of the words in an array.
            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            ////var res= Arr.Order(new CaseInsensitiveComparer());
            ////OR
            ////var res = Arr.OrderBy(x => x, StringComparer.OrdinalIgnoreCase);

            //foreach (var item in res)
            //    Console.WriteLine(item);
            #endregion

            #region 3. Sort a list of products by units in stock from highest to lowest.
            //var res = ProductList?.OrderByDescending(p => p.UnitsInStock);

            //foreach (var item in res)
            //    Console.WriteLine(item);    
            #endregion

            #region 4. Sort a list of digits, first by length of their name, and then alphabetically by the name itself.

            //string[] Arr = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};

            //var res = Arr.OrderBy(x => x.Length).ThenBy(x => x); 
            //foreach (var item in res)
            //    Console.WriteLine(item);

            #endregion

            #region 5. Sort first by-word length and then by a case-insensitive sort of the words in an array.
            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            //var  res= Arr.OrderBy(x => x.Length).ThenBy(x => x, StringComparer.OrdinalIgnoreCase);
            //foreach (var item in res)
            //    Console.WriteLine(item);
            #endregion

            #region 6. Sort a list of products, first by category, and then by unit price, from highest to lowest.
            //var res = ProductList?.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);

            //foreach (var item in res)
            //    Console.WriteLine(item);

            #endregion

            #region 7. Sort first by-word length and then by a case-insensitive descending sort of the words in an array.
            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            //var res = Arr.OrderBy(x => x.Length).ThenByDescending(x=>x ,StringComparer.OrdinalIgnoreCase);

            //foreach (var item in res)
            //    Console.WriteLine(item);
            #endregion
            #region 8. Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.

            //string[] Arr = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
            //var res = Arr.Where(x => x[1] == 'i').Reverse();

            //foreach (var item in res)
            //    Console.WriteLine(item);
            #endregion
            #endregion

            #region LINQ – Transformation Operators
            #region 1. Return a sequence of just the names of a list of products.
            //var res = ProductList?.Select(p => p.ProductName);

            //foreach (var item in res)
            //    Console.WriteLine(item);
            #endregion

            #region 2. Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types).

            //string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            //var toLower = words.Select(p => p.ToLower());
            //var toUpper = words.Select(p => p.ToUpper());

            //foreach (var item in toLower)
            //    Console.WriteLine(item);

            //Console.WriteLine("\n");
            //foreach (var item in toUpper)
            //    Console.WriteLine(item);

            #endregion
            #region 3. Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.

            //var res = ProductList?
            //    .Select(p => new { p.ProductName, Price = p.UnitPrice, p.Category });

            //foreach (var item in res)
            //    Console.WriteLine(item);
            #endregion
            #region 4. Determine if the value of int in an array matches their position in the array.
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var res = Arr.Select((v, i) => v == i)
            //    .Select((v, i) => new {idx = i, value = v});

            //Console.WriteLine("Number: In-Place?");
            //foreach (var x in res)
            //    Console.WriteLine($"{x.idx}: \t{x.value}");
            #endregion

            #region 5. Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.

            //int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            //int[] numbersB = { 1, 3, 5, 7, 8 };

            //var res = from A in numbersA
            //          from B in numbersB
            //          where A < B
            //          select new { A, B };

            //foreach (var pair in res)
            //    Console.WriteLine($"{pair.A} is less than {pair.B}");

            #endregion

            #region 6. Select all orders where the order total is less than 500.00.

            //var res = CustomerList?.SelectMany(c => c.Orders)
            //    .Where(o => o.Total > 500m);

            //foreach (var item in res)
            //    Console.WriteLine(item);

            #endregion


            #region 7. Select all orders where the order was made in 1998 or later.

            //var res = CustomerList?.SelectMany(c => c.Orders)
            //    .Where(o => o.OrderDate.Year >= 1998);

            //foreach (var item in res)
            //    Console.WriteLine(item);
            #endregion

            #endregion

        }

    }
}