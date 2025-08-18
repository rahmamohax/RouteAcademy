using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmnet
{
    enum SecurityPrivileges
    {
        Guest, Developer, Secretary, DBA
    }
    enum Gender { Male, Female }

    

    internal class Employee
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }

        public SecurityPrivileges SecurityLevel  { get; set; }
        public decimal Salary { get; set; }
        public Date HiringDate { get; set; }

        public Employee(int id, string name, Gender gender, SecurityPrivileges securityLevel, decimal salary, Date hiringDate)
        {
            Id = id;
            Name = name;
            SecurityLevel = securityLevel;
            Salary = salary;
            Gender = gender;
            HiringDate = hiringDate;
        }

        public override string ToString()
        {
            return $"Id: {Id}\n" +
                $"Name: {Name}\n" +
                $"Salary: {Salary}\n" +
                $"Security Level: {SecurityLevel}\n" +
                $"Hiring Date: {HiringDate}";
        }

    }


}
