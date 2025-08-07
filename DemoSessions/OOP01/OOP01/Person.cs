using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP01
{
    internal struct Person
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public Person(string _name, int _age)
        {
            Age = _age;
            Name = _name;
            
        }
    }
}
