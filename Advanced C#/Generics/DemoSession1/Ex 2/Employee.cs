using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSession1.Ex_2
{
    internal class Employee
    {
        public Employee(int id, string? name, decimal salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Salary { get; set; }

        #region Operator Overloading

        #endregion
        public override string ToString()
        {
            return $"Id = {Id}, Name= {Name}, Salary= {Salary:c}";
        }
    }
}
