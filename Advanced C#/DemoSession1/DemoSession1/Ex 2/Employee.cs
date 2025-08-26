using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSession1.Ex_2
{
    internal class Employee : IEquatable<Employee>
    {

        public bool Equals(Employee? other)
        {
            if (other is not null)
                return other?.Id == Id && other?.Name == Name && other?.Salary == Salary;
            return false;
        }
        public override bool Equals(object? obj)
        {
            ///Is & As Casting Operators:
            /// 1. IS Operator:
            ///   -> checks if an object is of a specific type
            ///   
            /// 2. AS Operator:
            ///   -> tries to cast an object to a specific type

            #region Unsafe Way Using Explicit Casting
            //Employee employee = (Employee?) obj ;
            //if (employee is not null) 
            //    return employee?.Id == Id && employee?.Name == Name && employee?.Salary == Salary;
            //return false; 
            #endregion

            #region IS Operator
            //1. IS Operator: For Check and Casting[optional with Pattern Matching] Object
            // -> True : if obj is Employee OR Type Inhirit from Employee
            // -> False : obj isn't an Employee

            //if (obj is  Employee employee /* <- Pattern Matching Casting */)
            //{
            //    return employee?.Id == Id && employee?.Name == Name && employee?.Salary == Salary;

            //}
            //else return false; 
            #endregion

            #region AS Operator
            //2. AS Operator: For Casting obj to Employee
            Employee? employee = obj as Employee;
            if (employee is not null)
                return employee?.Id == Id && employee?.Name == Name && employee?.Salary == Salary;
            return false;
            #endregion
        }

        public override int GetHashCode()
        {
            //return Id.GetHashCode() +( Name?.GetHashCode() ?? 0) + Salary.GetHashCode();
            return HashCode.Combine(Id, Name, Salary); // Utility Method
        }
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

        /// '==' Operator                         vs                      Equals Method
        /// 1. With UserDefined Struct:
        ///     -> '==' operator doesn't exist, can't be used unless overload
        ///     -> Equals Method is Inherited from ValueType Class (which compares field values)
        ///     
        /// 2. With UserDefined Class:
        ///    -> '==' operator compares references
        ///    -> Equals Method is Inherited from Object that compares references


        public static bool operator ==(Employee left, Employee right)
        {
            //return (left.Id == right.Id) && (left.Name == right.Name) && (left.Salary == right.Salary);
            return left.Equals(right);
        }
        public static bool operator !=(Employee left, Employee right)
        {
            //return (left.Id != right.Id) || (left.Name != right.Name) || (left.Salary != right.Salary);
            return !left.Equals(right);

        }
        #endregion
        public override string ToString()
        {
            return $"Id = {Id}, Name= {Name}, Salary= {Salary:c}";
        }

        
    }
}
