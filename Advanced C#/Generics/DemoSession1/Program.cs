using DemoSession1.Ex_1;
using DemoSession1.Ex_2;

namespace DemoSession1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Ex 1
            //int a = 5, b = 3;
            //Helper.Swap(ref a, ref b); 
            #endregion

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
            //int index = Helper.LinearSearch(points, point);

            Employee employee = new Employee(10, "Ali", 2000);
            Employee employee1 = new Employee(20, "Khalid", 3000);  

            if (employee == employee1) // compare references
                Console.WriteLine("==");
        }
    }
}