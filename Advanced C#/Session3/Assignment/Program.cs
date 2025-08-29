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
            #region  implement a function to reverse the elements of a queue using a stack.Given a Queue,
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
            string? input = Console.ReadLine();

            if (input is not null)
            {
                if (IsBalanced(input))
                    Console.WriteLine("Balanced");
                else
                    Console.WriteLine("Not Balanced"); 
            }

            #endregion


        }
    }
}