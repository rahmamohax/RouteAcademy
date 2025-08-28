using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSession2.DefaultConstraint
{
    internal class TypeB : TypeA
    {
        public override void MyFun01<T>(T? value) where T : class
        {
            base.MyFun01(value);
        }

        public override void MyFun02<T>(T? value) where T : default //can't change the defualt(no constraint) of the function
        {
            base.MyFun02(value);
        }
    }
}
