using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session3.BuiltinDelegate
{
    internal static class TestBuiltinDelegates
    {

        public static void Print()
        {
            Console.WriteLine("Hello Route!");
        }

        public static void Print(string name)
        {
            Console.WriteLine("Hello " + name);
        }
    }

}
