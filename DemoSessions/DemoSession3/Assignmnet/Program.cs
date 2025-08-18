using Assignmnet;

namespace assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees =
            {
                new Employee(1, "Alice", Gender.Male, SecurityPrivileges.DBA, 3000, new Date(10, 5, 2020)),
                new Employee(2, "Meme", Gender.Female, SecurityPrivileges.Guest, 5000, new Date(24, 7, 2022)),
                new Employee(3, "Rahma", Gender.Female, SecurityPrivileges.Developer, 23000, new Date(10, 10, 2025)),
            };

            foreach (Employee employee in employees)
                Console.WriteLine(employee);
        }
    }
}