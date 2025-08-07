using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSession5.Interface_Ex01
{
    internal interface IType
    {
        //Default Access Modifier => "Public"
        //"Private" Acces Modifier is not allowed


        ///What you can write inside an Interface:
        ///1. Property Signature
        public int MyProperty { get; set; }

        ///2. Method Signature
        public void MyMethod();

        //3. Defaulf Implemented Method
        public void Print()
        {
            Console.WriteLine("Default Implementation");
        }

        //4. Static Members:
        ///- Static Fields
        ///- Static Properties
        ///- Static Methods
        ///- Static Events


    }
}
