// See https://aka.ms/new-console-template for more information

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter Number of Tasks: ");
        int num = int.Parse(Console.ReadLine());
        int[] id = new int[num];
        string[] Title = new string[num];
        string[] desc = new string[num];

        for (int i = 0; i < num; i++) {
            Console.Write($"Input ID of Task {i + 1}: ");
            int test = int.Parse(Console.ReadLine());
            foreach (int x in id)
            {
                if (x == test)
                {
                    Console.WriteLine("ID must be unique");
                    break;
                }
                else id[i] = test;
            }
            Console.WriteLine("Type Task's Title: ");
            Title[i] = Console.ReadLine();

            
            do
            {
                Console.WriteLine("Do you wants to add description? (Y/N)");
                char des = char.Parse(Console.ReadLine());

                if (des == 'Y' || des == 'y')
                {
                    desc[i] = Console.ReadLine();
                    break;
                }
                else if (des == 'N' || des == 'n')
                {
                    desc[i] = null;
                    break;
                }
                else Console.WriteLine("Invalid Input");
            }
            while (true);
            
        }

        for (int i = 0; i < num; i++) {
            Console.WriteLine($"Task {i+1}'s ID: {id[i]}");
            Console.WriteLine($"Task {i + 1}'s Title: {Title[i]}");
            if(desc[i] != null) 
                Console.WriteLine($"Task {i + 1}'s Description: {desc[i]}");

        }

    }
}