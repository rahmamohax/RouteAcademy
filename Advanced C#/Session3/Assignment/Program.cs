using Assignment.Book;

namespace assignment
{
    class Program
    {
        public static void ReverseQueue(Queue<int> q)
        {
            Stack<int> stack = new Stack<int>();

            while (q.Count > 0)
                stack.Push(q.Dequeue());

            while (stack.Count > 0)
                q.Enqueue(stack.Pop());
        }
        public static bool IsBalanced(string expr)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char ch in expr)
            {
                if (ch == '(' || ch == '[' || ch == '{')
                {
                    stack.Push(ch);
                }
                else if (ch == ')' || ch == ']' || ch == '}')
                {
                    if (stack.Count == 0) return false;

                    char top = stack.Pop();
                    if ((ch == ')' && top != '(') ||
                        (ch == ']' && top != '[') ||
                        (ch == '}' && top != '{'))
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }
        static void Main(string[] args)
        {
            #region  Implement a function to reverse the elements of a queue using a stack.Given a Queue,
            //Queue<int> q = new Queue<int>();
            //q.Enqueue(1);
            //q.Enqueue(2);
            //q.Enqueue(3);
            //q.Enqueue(4);

            //Console.WriteLine("Original Queue: " + string.Join(", ", q));

            //ReverseQueue(q);
            //Console.WriteLine("Reversed Queue: " + string.Join(", ", q));
            #endregion

            #region Given a Stack, implement a function to check if a string of parentheses is balanced using a stack.
            //string? input = Console.ReadLine();

            //if (input is not null)
            //{
            //    if (IsBalanced(input))
            //        Console.WriteLine("Balanced");
            //    else
            //        Console.WriteLine("Not Balanced"); 
            //}

            #endregion

            #region Considering the Code Below , Write Down the Body of all Listed Methods and Properties , you need to Define fPtr as the following cases:

            List<Book> books = new List<Book>()
            {
                new Book(12345, "C# in Depth", new string[] { "Ali Ahmed", "Mohamed Khaled", "Manar Saad" }, new DateTime(2021, 5, 1), 45.5m),
                new Book(67890, ".NET Core", new string[] { "Amr Ali", "Omar A.", "Yassin Ahmed" }, new DateTime(2019, 3, 15), 60m)
            };

            //a.User Defined Delegate Datatype
            Console.WriteLine("=== a) User Defined Delegate ===");
            BookFunctionsDelegate bookDelegate = BookFunctions.GetTitle;
            LibraryEngine.ProcessBook(books, bookDelegate);
            Console.WriteLine("\n");

            //b.BCL Delegates
            Console.WriteLine("=== b) BCL Delegates ===");
            Func<Book, string> bookFunc = BookFunctions.GetAuthors;
            foreach (Book book in books)
                Console.WriteLine(bookFunc(book));
            Console.WriteLine("\n");

            //c.Anonymous Method(GetISBN)
            Console.WriteLine("=== c) Anonymous Method(GetISBN) ===");
            Func<Book, int> GetISBN = delegate (Book book) { return book.ISBN; };
            foreach (Book book in books)
                Console.WriteLine("Book ISBN: " + GetISBN(book));
            Console.WriteLine("\n");

            //d.Lambda Expression(GetPublicationDate)
            Console.WriteLine("=== d) Lambda Expression(GetPublicationDate) ===");
            Func<Book, DateTime> GetPublicDate = (book) => book.PublicationDate;
            foreach (Book book in books) 
                Console.WriteLine(GetPublicDate(book));
            Console.WriteLine("\n");

            #endregion
        }
    }
}