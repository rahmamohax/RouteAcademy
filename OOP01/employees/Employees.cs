using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Program;

namespace employees
{
    public class Employees
    {
        public int ID { get; set; }
        public string Name { get; set; }
        HiringDate HiringDate { get; set; }
        public decimal Salary { get; set; }
        Gender Gender { get; set; }
        SecurityPrivileges Privileges { get; set; }

        public Employees(int id, string name, Gender gender, decimal salary, HiringDate hiringD,   SecurityPrivileges SecLevel)
        {
            ID = id;
            Name = name;
            HiringDate = hiringD;
            Salary = salary;
            Gender = gender;
            Privileges = SecLevel;            
        }

        public Employees()
        {
        }

        public override string ToString()
        {
            return $"ID: {ID}\n" +
                $"Name: {Name}\n" +
                $"HiringDate: {HiringDate}\n" +
                $"Salary: {Salary}\n" +
                $"Gender: {Gender}\n" +
                $"Security Level: {Privileges}";
        }
    }
}
