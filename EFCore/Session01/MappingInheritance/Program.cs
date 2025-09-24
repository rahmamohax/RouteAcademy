using MappingInheritance.Contexts;
using MappingInheritance.Data.Models;

namespace MappingInheritance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using CompanyContext context = new CompanyContext();

            var emp01 = new FullTimeEmployee()
            {
                Name = "Assem",
                Age = 20,
                Address = "Giza",
                Salary = 20000,
                StartDate = DateTime.Now,
            };

            var emp02 = new PartTimeEmployee()
            {
                Name = "Khaled",
                Age = 20,
                Address = "Giza",
                CountOfHrs = 15,
                HourRate = 250
            };

            //context.FullTimeEmployees.Add(emp01);
            context.Employees.Add(emp01);
            //context.PartTimeEmployees.Add(emp02);
            context.Employees.Add(emp02);

            context.SaveChanges();
            #region TPCT [Table Per Concrete Type]  (Makes a table for each type)

            //var fullemp = context.PartTimeEmployees.FirstOrDefault();
            //Console.WriteLine(fullemp?.Name + ": " + fullemp?.CountOfHrs);          

            //var fullemp = context.Employees.ToList();
            //foreach (var item in fullemp)
            //{
            //    Console.WriteLine(item?.Name);

            //}

            //foreach (var item in fullemp.OfType<FullTimeEmployee>())
            //{
            //    Console.WriteLine(item?.Name);

            //}
            #endregion

            #region TPH [Table Per Hierarchy] (Adds them all in one table with  a discreminator)
            // 1	Assem	Giza	20	FullTimeEmployee	20000.00	2025-09-22 20:57:17.6016832 	NULL	NULL
            // 2	Khaled	Giza	20	PartTimeEmployee	NULL	            NULL	                 15	    250.00
            #endregion

            #region TPT [Table Per Type]

            #endregion

        }
    }
}