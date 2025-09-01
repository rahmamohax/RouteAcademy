using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
        public delegate string BookFunctionsDelegate(Book B);
    public class LibraryEngine
    {

        public static void ProcessBooks(List<Book> bList, BookFunctionsDelegate fPtr)
        {
            foreach (Book B in bList)
                Console.WriteLine(fPtr(B));
        }

    }
}
