using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSession4OOP.NeedOfCastingOperator
{
    //Model : PocoClass : Database Table
    internal class User
    {
        public int Id { get; set; } // int
        public string? FullName { get; set; } //varchar(max)
        public string? Email { get; set; }    //varchar(max)
        public string? Password { get; set; }  //varchar(max)
    }
}
