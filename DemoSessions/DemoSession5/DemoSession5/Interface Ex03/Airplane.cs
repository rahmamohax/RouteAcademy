using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSession5.Interface_Ex03
{
    internal class Airplane : Vechile, IFlyable, IMoveable
    {
        //same implementation for both IFlyable and IMoveable
        public void Backward()
        {
            throw new NotImplementedException();
        }

        void IFlyable.Forward()
        {
            Console.WriteLine("Moving Forward in Sky");
        }

        void IMoveable.Forward()
        {
            Console.WriteLine("Moving Forward on Ground");
        }
    }
}
