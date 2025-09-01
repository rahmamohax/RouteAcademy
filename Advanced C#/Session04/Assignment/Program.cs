using Assignment;
using System.Collections;

namespace assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Considering the Code Below , Write Down the Body of all Listed Methods and Properties , you need to Define fPtr as the following cases:

            //List<Book> books = new List<Book>()
            //{
            //    new Book(12345, "C# in Depth", new string[] { "Ali Ahmed", "Mohamed Khaled", "Manar Saad" }, new DateTime(2021, 5, 1), 45.5m),
            //    new Book(67890, ".NET Core", new string[] { "Amr Ali", "Omar A.", "Yassin Ahmed" }, new DateTime(2019, 3, 15), 60m)
            //};

            ////a.User Defined Delegate Datatype
            //Console.WriteLine("=== a) User Defined Delegate ===");
            //BookFunctionsDelegate bookDelegate = BookFunctions.GetTitle;
            //LibraryEngine.ProcessBooks(books, bookDelegate);
            //Console.WriteLine("\n");

            ////b.BCL Delegates
            //Console.WriteLine("=== b) BCL Delegates ===");
            //Func<Book, string> bookFunc = BookFunctions.GetAuthors;
            //foreach (Book book in books)
            //    Console.WriteLine(bookFunc(book));
            //Console.WriteLine("\n");

            ////c.Anonymous Method(GetISBN)
            //Console.WriteLine("=== c) Anonymous Method(GetISBN) ===");
            //Func<Book, int> GetISBN = delegate (Book book) { return book.ISBN; };
            //foreach (Book book in books)
            //    Console.WriteLine("Book ISBN: " + GetISBN(book));
            //Console.WriteLine("\n");

            ////d.Lambda Expression(GetPublicationDate)
            //Console.WriteLine("=== d) Lambda Expression(GetPublicationDate) ===");
            //Func<Book, DateTime> GetPublicDate = (book) => book.PublicationDate;
            //foreach (Book book in books)
            //    Console.WriteLine(GetPublicDate(book));
            //Console.WriteLine("\n");

            #endregion
            #region Given an array of integers, count the frequency of each element using a hash table.
            //int[] ints = { 1, 2, 4, 6, 7, 8, 9, 7, 6, 3, 3, 5, 6, 3, 4, 2, 1, 3, 5, 3, 2, 6, 4, 2, 5, 6, 4 };
            //Hashtable freq = new Hashtable();
            //foreach (int i in ints) {
            //    if (freq.ContainsKey(i)) freq[i] = (int)freq[i] + 1;
            //    else freq[i] = 1;
            //}

            //foreach (DictionaryEntry x in freq)
            //    Console.WriteLine($"{x.Key} => {x.Value}");
            #endregion

            #region You have a hashtable where its values are integers, find the key associated with the highest value.
            //Hashtable ht = new Hashtable()
            //    {
            //        {"A", 10}, {"B", 25}, {"C", 15}
            //    };

            //object maxKey = "";
            //int maxValue = int.MinValue;
            //foreach (DictionaryEntry item in ht)
            //{
            //    int value = (int)item.Value;
            //    if(value > maxValue)
            //    {
            //        maxValue = value;
            //        maxKey = item.Key;
            //    }
            //}
            //Console.WriteLine($"Key with highest value: {maxKey}, Value = {maxValue}");

            #endregion

            #region You have a hashtable , the  user will enter targetValue find all keys that associated with a specific targetValue
            Dictionary<string, string> map = new Dictionary<string, string>()
            {
                {"key1","apple"}, {"key2","banana"}, {"key3","apple"}
            };

            string targetValue = "apple";
            foreach (var kvp in map) {
                if (kvp.Value == targetValue)
                {
                    Console.WriteLine(kvp.Key);
                }
            }
            #endregion
        }
    }
}