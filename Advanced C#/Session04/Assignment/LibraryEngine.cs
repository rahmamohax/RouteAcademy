using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class LibraryEngine
    {
        public delegate string BookDelegate(Book B);

        public static void ProcessBooks(List<Book> bList, BookDelegate fPtr)
        {
            foreach (Book B in bList)
                Console.WriteLine(fPtr(B));
        }

    }
}
