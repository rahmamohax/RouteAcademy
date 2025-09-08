using EFCore01.Contexts;
using EFCore01.Entities;
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

        }
    }
}