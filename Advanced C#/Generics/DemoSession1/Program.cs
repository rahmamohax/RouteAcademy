using DemoSession1.EqualityComparer;
using DemoSession1.Ex_1;
using DemoSession1.Ex_2;

namespace DemoSession1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Ex1 Swap
            //int a = 5, b = 3;
            //Helper.Swap(ref a, ref b); 
            #endregion

            #region Ex2 Linear Search
            //int[] ints = { 1, 2, 0, 9, 7, 8, 5, 6, 4, 22 };
            //int key = 5;
            //int index = Helper.LinearSearch(ints, key);
            //Console.WriteLine(index);

            //Point[] points =
            //{
            //    new Point(1, 2),
            //    new Point(10, 20),
            //    new Point(100, 200),
            //    new Point(1000, 2000)
            //};

            //Point point = new Point(10, 20);
            //int index = Helper<Point>.LinearSearch(points, point);
            //Console.WriteLine(index);

            //Employee employee = new Employee(10, "Ali", 2000);
            //Employee employee1 = new Employee(20, "Khalid", 3000);  

            //if (employee == employee1) // compare references
            //    Console.WriteLine("==");

            //Employee[] employees =
            //{
            //    new Employee(10, "ALi", 5000),
            //    new Employee(20, "Maram", 15000),
            //    new Employee(30, "Amr", 2000),
            //    new Employee(40, "Wael", 3000),
            //};

            //Employee employee = new Employee(30, "Amr", 2000);

            //int index = Helper<Employee>.LinearSearch(employees, employee);
            //Console.WriteLine(index); 
            #endregion

            #region Ex3 HashCode
            //Employee employee = new Employee(10, "Mona", 5000);
            //Employee employee2 = new Employee(10, "Mona", 5000);

            //Console.WriteLine($"employee = {employee.GetHashCode()}");
            //Console.WriteLine($"employee2 = {employee2.GetHashCode()}");

            //HashSet<Employee> employees = new HashSet<Employee>();
            //Employee employee1 = new Employee(10, "Mona", 5000);
            //Employee employee2 = new Employee(10, "Mona", 5000);
            //employees.Add(employee1);

            //Console.WriteLine(employee1.Equals(employee2)); //true
            //Console.WriteLine(employees.Contains(employee2)); //false 
            #endregion

            Employee[] employees =
            {
                new Employee(10, "ALi", 5000),
                new Employee(20, "Maram", 15000),
                new Employee(30, "Amr", 2000),
                new Employee(40, "Wael", 3000),
            };
            Employee employee = new Employee(0, "Wael", 0);

            int index = Helper<Employee>.LinearSearch(employees, employee, new EmpNameEquComp());
            Console.WriteLine(index);
        }
    }
}