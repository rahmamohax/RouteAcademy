using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Book
{
    public class BookFunctions
    {
        public static string GetTitle(Book book) => book.Title;

        public static string GetAuthors(Book book) { 
            if (book is not null)
                return string.Join(", ", book.Authors);
            return "-1";
        }

        public static string GetPrice(Book book) => book.Price.ToString();
    }
}
