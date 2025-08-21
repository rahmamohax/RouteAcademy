using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class BookFunctions
    {
        public static string GetTitle(Book B) => B.Title;
        public static string GetAuthors(Book B) => string.Join(", ", B.Authors);
        public static string GetPrice(Book B) => B.Price.ToString("C");
    }


}
