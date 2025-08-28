using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSession2.DefaultConstraint
{
    internal class TypeA
    {
        public virtual void MyFun01<T>(T? value) where T : class
        {
            Console.WriteLine(value);
        }
        public virtual void MyFun02<T>(T? value)
        {
            Console.WriteLine(value);
        }
    }
}
