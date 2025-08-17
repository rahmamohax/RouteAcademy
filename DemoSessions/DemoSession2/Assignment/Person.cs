using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal struct Person
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}
