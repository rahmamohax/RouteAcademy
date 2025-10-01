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
            var loan = new Loan()
            {
                LoanDate = DateTime.Now,
                Status = LoanStatus.Borrowed
            };
            context.Loans.Add(loan);
            context.SaveChanges();

            var memberloan = new MemberLoans()
            {
                MemberId = 3,
                BookId = 1,
                LoanId = 2,
                DueDate = DateTime.Now.AddDays(5)
            };

            context.MemberLoans.Add(memberloan);
            context.SaveChanges();

            //4. After 10 Days Member with id 1 Returned The Book
            //     var existingLoan = context.MemberLoans
            //         .Include(ml => ml.Loan)
            //         .FirstOrDefault(l => l.MemberId == 1 && l.BookId == 2);
            //     if (existingLoan != null)
            //     {
            //         existingLoan.ReturnDate = existingLoan.Loan.LoanDate.AddDays(10);
            //         existingLoan.Loan.Status = LoanStatus.Overdue;
            //         context.SaveChanges();
            //         Console.WriteLine("📖 Book returned after 10 days");
            //     }


            //5. Retrieve all members who currently have active loans(i.e., loans that have not yet been returned)
            var res = context.MemberLoans
                .Include(m => m.Member)
                .Include(l => l.Loan)
                .Where(l => l.Loan.Status == LoanStatus.Borrowed)
                .Select(m => m.Member).ToList();

            foreach (var item in res)
                Console.WriteLine(item.Name);
        }
    }
}