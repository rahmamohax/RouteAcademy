namespace ToDoTask
{
    class ToDo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int points;
            do
            {
                Console.Write("Enter No. of Points: "); 
            } while (!int.TryParse(Console.ReadLine(),out points) || points<=0 );

            ToDo[] list = new ToDo[points];
            for (int i = 0; i < points; i++)
            {
                list[i] = new ToDo();
                int id;
                string title;
                do
                {
                    Console.Write($"Enter Task {i+1}'s Id: ");
                }
                while (!int.TryParse(Console.ReadLine(), out id));
                list[i].Id = id;

                do
                {
                    Console.Write("Enter Title: ");
                    title = Console.ReadLine();
                }
                while (title is null);
                list[i].Title = title;

                char choise;
                do
                {
                    Console.Write("Do you want to add description? (Y y N n) ");

                } while (!char.TryParse(Console.ReadLine(), out choise) ||
                    !(choise == 'Y' || choise == 'y' || choise == 'N' || choise == 'n'));

                if (choise == 'Y' || choise == 'y')
                    list[i].Description = Console.ReadLine();
                //else list[i].Description = null;
            }

        }
    }
}