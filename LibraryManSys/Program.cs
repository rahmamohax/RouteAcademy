using LibraryManSys.Contexts;
using LibraryManSys.Data.Models;
using LibraryManSys.Data.Seeding;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;

namespace LibraryManSys
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LMSContext context = new LMSContext();

            //LMSSeeding.Seed(context);

            //1. Retrieve the book title, its category title , and the author’s full name for all books whose price is greater than 300.
            //var res = context.Books
            //    .Where(b => b.Price > 300)
            //    .Select(b => new
            //    {
            //        b.Title,
            //        Category = b.Category.Title,
            //        Author = b.Author.FirstName + " " + b.Author.LastName
            //    })
            //    .ToList();

            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}

            //2. Retrieve All Authors And His / Her Books if Exists.
            //var auths = context.Authors.Include(a => a.Books).ToList();

            //foreach (var item in auths)
            //{
            //    Console.WriteLine("Author: " + item.FirstName);
            //    foreach (var i in item?.Books)
            //    {
            //        Console.WriteLine( i.Title );
            //    }
            //    Console.WriteLine();
            //}

            //3. Member with id 1 Want To Borrow The Book With Id 2 And He Will Return it After 5 Days


            //4. After 10 Days Member with id 1 Returned The Book

            //5. Retrieve all members who currently have active loans(i.e., loans that have not yet been returned)

        }
    }
}