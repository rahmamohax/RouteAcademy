using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSession5.Built_in_Interfaces
{
    internal class Employee : ICloneable, IComparable<Employee>
    {
        #region Properties
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Salary { get; set; }
        public Department? Department { get; set; } 
        #endregion

        public Employee()
        {
            
        }

        //Copy Constructor: Spetial Ctor Used for Deep Copy
        public Employee(Employee employee)
        {
            this.Id = employee.Id;
            this.Name = employee.Name;
            this.Salary = employee.Salary;
            this.Department = (Department?) employee.Department?.Clone();
        }
        public object Clone()
        {
            return new Employee(this); // cloning using copy ctor
            //return new Employee()
            //{
            //    Id = this.Id,
            //    Name = this.Name,
            //    Salary = this.Salary,
            //    Department = (Department?) this.Department?.Clone(),
            //};
        }


        //+ve => this.prop > obj.prop
        //-ve => this.prop < obj.prop
        // 0 => this.prop = obj.prop
        public int CompareTo(Employee? obj)
        {
            //Employee? other = (Employee?) obj;  //Explicit Casting
            //                                    //Unsafe => may throw exception

            return this.Salary.CompareTo(obj?.Salary);

            //if (other is null) // this is greater than
            //    return 1;
            //if (this.Salary > other.Salary)
            //    return 1;
            //else if(this.Salary < other.Salary) return -1;
            //return 0;
        }
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Salary: {Salary:c}";
        }
    }
}
