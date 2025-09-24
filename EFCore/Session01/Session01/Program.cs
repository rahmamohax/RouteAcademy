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
            //using CompanyDbContext context = new CompanyDbContext();

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

            CompanyDbContext context = new CompanyDbContext();

            //CompanyDbContextSeed.Seed(context);

            #region Loading
            ///Data Loading
            ///1. Eager Loading: retrieves related data at the same time
            ///      - Uses left join when relation is Optional
            ///      - Inner join if relation is Mandatory
            ///2. Explicit Loading: retrieves    related data on-demand, but manually triggered by the developer
            ///     - Data is not loaded automatically.
            ///     - Requires calling a method to load related data.
            ///3. Lazy Loading: retrieves related data only when it is first accessed, happens automatically

            #region Auto Loading (Runtime Loading)
            //var emp = (from e in context.Employees
            //          where e.Id == 2
            //          select e).FirstOrDefault();

            //var empWorkDept= (from d in context.Departments
            //                  where d.Id == emp.WorkDepartmentId
            //                  select d).FirstOrDefault();  //auto loading

            //if (emp is not null)
            //{
            //    Console.WriteLine(emp);
            //    Console.WriteLine(emp.WorkDepartment?.Name ?? "no WorkDepartment");
            //    Console.WriteLine(emp.ManagesDepartment?.Name ?? "no ManagesDepartment");
            //} 
            #endregion

            #region Eager Lodaing

            //var emp = context.Employees.Include(e => e.WorkDepartment).ThenInclude(d => d.Manager)
            //                        .Include( e=> e.ManagesDepartment)
            //                        .FirstOrDefault(e => e.Id == 2);

            //Console.WriteLine(emp.Name + " " + emp.ManagesDepartment?.Name + " " + emp.WorkDepartment?.Name);

            #endregion

            #region Explicit Loading
            //Uses Entry() combined with either Reference() or Collection()

            //var emp = context.Employees.FirstOrDefault(e => e.Id == 2);

            //if (emp != null)
            //{
            //    context.Entry(emp).Reference(e => e.WorkDepartment).Load();
            //    context.Entry(emp).Reference(e => e.ManagesDepartment).Load();
            //}

            //var dept5 = context.Departments.FirstOrDefault(d => d.Id == 5);

            //context.Entry(dept5).Collection(d => d.Employees).Load();
            //context.Entry(dept5).Reference(d => d.Manager).Load();
            #endregion

            #region Lazy Loading

            //var emp = context.Employees.FirstOrDefault(e => e.Id == 2);

            #endregion

            #region Joins (Join, GroupJoin)

            //manager relation
            //var res = context.Employees.Join(context.Departments, e => e.Id, d => d.ManagerId, (emp, dept) => new {emp, dept});
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item.emp.Name);
            //    Console.WriteLine(item.dept.Name);
            //    Console.WriteLine("\n");

            //}

            //work relation
            //var res = context.Departments.Join(context.Employees, d => d.Id, e => e.WorkDepartmentId,
            //(dept ,emp) => new { emp, dept });

            //res = from d in context.Departments
            //      join e in context.Employees
            //      on d.Id equals e.WorkDepartmentId
            //      select new 
            //      {
            //          emp =e,
            //          dept = d,
            //      };

            //var res1 = context.Employees.Join(context.Departments, e => e.WorkDepartmentId, d => d.Id, (emp, dept) => new { emp, dept });


            //var res = context.Departments.GroupJoin(context.Employees, d => d.Id, e => e.WorkDepartmentId,
            //    (dept, emps) => new { dept, emps }
            //    );

            //foreach (var item in res)
            //{
            //    Console.WriteLine("Department: " + item.dept.Name);
            //    foreach (var i in item.emps)
            //    {
            //        Console.Write(i.Name + "\t");

            //    }
            //    Console.WriteLine("\n");
            //}


            //var res = context.Departments.GroupJoin(context.Employees, d => d.Id, e => e.WorkDepartmentId,
            //   (dept, emps) => new { dept, emps }
            //   ).SelectMany( group => group.emps, (group, emp) => new
            //   {
            //       department = group.dept,
            //       emp
            //   } );

            //foreach (var item in res)
            //{
            //    Console.WriteLine($"Dept Id: {item.department?.Id}, dept name: {item.department?.Name}, emp name: {item.emp?.Name}");
            //}


            #region Cross Join
            //var res = from d in context.Departments
            //          from e in context.Employees
            //          select new { d, e };

            //foreach (var item in res)
            //{
            //    Console.WriteLine($"dept: {item.d.Name}\temp: {item.e.Name}");   
            //}
            #endregion
            #endregion
            #endregion

            var items =context.DepartmentsAndEmps.ToList();
            foreach (var item in items)
                Console.WriteLine($"{item.DepartmentName} : {item.EmployeeName} ");

        }
    }
}