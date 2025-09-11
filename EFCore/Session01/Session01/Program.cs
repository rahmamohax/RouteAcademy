using EFCore01.Contexts;
using EFCore01.Data.DataSeeding;
using EFCore01.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore01
{
    /// EFCore: ORM in .NET
    /// ORM => Object Relation Mapping

    //1. Mapping
    //      Code First
    //      DB First
    //2. LINQ-2-EFCore [LINQ --> EF Core --> SQL DB]
    class Program
    {
        public static void Main(string[] args)
        {
            //CompanyDbContext context = new CompanyDbContext();
            //context.Database.Migrate();

            //context.Employees.Where(e => e.EmpId == 0);

            #region CRUD Operations

            //CompanyDbContext context = new CompanyDbContext();

            //Way 1
            //try
            //{
            //    //Code
            //}
            //finally
            //{
            //    context.Dispose();
            //}


            //Way 2
            //using (context)
            //{
            //    //CRUD

            //    //no need to dispose [closes connnection by default]
            //}


            //Way 3
            using CompanyDbContext context = new CompanyDbContext();

            #region Create
            //var employee = new Employee()
            //{
            //    Name = "Test",
            //    Salary = 10000,
            //    Email = "test@test.com",
            //    Age = 20
            //};

            //employee.Name = "Khaled";

            //Console.WriteLine(context.Entry(employee).State); // detatched
            //context.Employees.Add(employee);
            //Console.WriteLine(context.Entry(employee).State); // added

            //Console.WriteLine();
            //var res= context.SaveChanges();
            //Console.WriteLine(context.Entry(employee).State); // Unchanged
            //Console.WriteLine(res);

            //employee.Name = "Omar";
            //Console.WriteLine(context.Entry(employee).State); // Modified

            // res = context.SaveChanges(); 
            #endregion

            #region Select
            ////var res = context.Employees.Where(e => e.EmpId == 1).FirstOrDefault();
            //var res = context.Employees.FirstOrDefault(e => e.EmpId == 1);
            //Console.WriteLine(res.Name);
            //Console.WriteLine(res.Salary); 
            #endregion

            #region Update

            // var res = context.Employees.FirstOrDefault(e => e.EmpId == 1);

            //res.Name = "Ahmed Ali";
            //context.SaveChanges();

            #endregion

            #region Delete
            // var res = context.Employees.FirstOrDefault(e => e.EmpId == 1);

            //context.Employees.Remove(res);
            //context.SaveChanges();
            #endregion
            #endregion

            //CompanyDbContext context = new CompanyDbContext();

            CompanyDbContextSeed.Seed(context);

        }
    }
}