using EFCore01.Contexts;
using EFCore01.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EFCore01.Data.DataSeeding
{
    public static class CompanyDbContextSeed
    {
        public static void Seed(CompanyDbContext context)
        {

            if (!context.Employees.Any())
            {
                var employeeData = File.ReadAllText("C:\\Users\\rhmar\\GitHub\\Route\\EFCore\\Session01\\Session01\\Data\\DataSeeding\\employees.json");
                var employees = JsonSerializer.Deserialize<List<Employee>>(employeeData);

                foreach (var item in employees)
                    context.Employees.Add(item);

                context.SaveChanges();
            }

            if (!context.Departments.Any())
            {
                var DepartmentData = File.ReadAllText("C:\\Users\\rhmar\\GitHub\\Route\\EFCore\\Session01\\Session01\\Data\\DataSeeding\\departments.json");
                var Departments = JsonSerializer.Deserialize<List<Department>>(DepartmentData);

                foreach (var item in Departments)
                    context.Departments.Add(item);

                context.SaveChanges();
            }
        }

    }
}
