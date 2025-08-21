using Assignment;

namespace assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Considering the Code Below, Write Down the Body of all Listed Methods and Properties and Constructor:

            var books = new List<Book>
            {
            new Book("12345", "C# Basics", new string[] {"Rahma", "Ali"}, new DateTime(2022, 5, 10), 150),
            new Book("67890", "Advanced C#", new string[] {"Omar"}, new DateTime(2023, 1, 20), 250)
            };

            LibraryEngine.ProcessBooks(books, new LibraryEngine.BookDelegate(BookFunctions.GetTitle));

            LibraryEngine.ProcessBooks(books, new LibraryEngine.BookDelegate(BookFunctions.GetAuthors));


            LibraryEngine.ProcessBooks(books, delegate (Book b) { return b.ISBN; });

            LibraryEngine.ProcessBooks(books, b => b.PublicationDate.ToShortDateString());

            #endregion
        }
    }
}