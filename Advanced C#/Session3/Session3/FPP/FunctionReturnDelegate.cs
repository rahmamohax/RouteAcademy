using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session3.FPP
{
    internal static class FunctionReturnDelegate
    {
        public static Action DelegateAction()
        {
            //return delegate { Console.WriteLine("Hello Route"); };
            return () => Console.WriteLine("Hello Route");
        }

        public static Predicate<int> DelegatePredicate()
        {
            //return delegate (int x ){ return x > 0; };
            return (int x) => x > 0;
        }
        public static Func<char[], string> DelegateFunc() { 
            //return delegate (char[] x) { return new string(x); };
            return (char[] x) => new string(x);
        }

    }
}
