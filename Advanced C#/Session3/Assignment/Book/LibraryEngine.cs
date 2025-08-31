using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Book
{
    internal class LibraryEngine
    {
        public static void ProcessBook( List<Book> books, BookFunctionsDelegate fPtr)
        {
            foreach (var book in books)
                Console.WriteLine(fPtr(book));
        }
    }
}
