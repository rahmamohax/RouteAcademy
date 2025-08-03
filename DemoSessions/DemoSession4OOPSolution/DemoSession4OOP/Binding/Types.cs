using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSession4OOP.Binding
{
    internal class TypeA
    {
        public int A { get; set; }

        public TypeA()
        {

        }
        public TypeA(int a)
        {
            A = a;
        }

  
        public void MyFun01()
        {
            Console.WriteLine("I'm  Parent (Base) : TypeA ");
        }

        public virtual void MyFun02()
        {
            Console.WriteLine($"A : {A}");
        }
    }

    internal class TypeB : TypeA
    {
        public  int B { get; set; }

        public TypeB()
        {

        }
        public TypeB(int a , int b):base(a)
        {
            B = b;
        }

        public new void MyFun01()//Static Polymorphism => New Version Of "MyFun01"
        {//Static Binded Method
            Console.WriteLine("I'm  Child (Derived) : TypeB ");
        }

        public override void MyFun02()//Dynamic Polymorphism
        {//Dynamic Binded Method : Must Be Non-Privte Visrtual Methat 
            Console.WriteLine($"A : {A} , B : {B} ");
        }
    }



    class TypeC : TypeB  //TypeB As Direct Parent , TypeA As InDirect Parent
    {
        public int C { get; set; }

        public TypeC(int a,  int b ,int c) :base(a,b)
        {
            C = c;
        }


        public new void MyFun01()//Static Polymorphism => New Version Of "MyFun01"
        {//Static Binded Method
            Console.WriteLine("I'm  Grand Child  : TypeC ");
        }

        public override void MyFun02()
        {
            Console.WriteLine($"A : {A} , B : {B} , C : {C} ");
        }
    }



    class TypeD : TypeC
    {
        public int D { get; set; }

        public TypeD( int a , int b ,int c, int d):base (a,b,c)
        {
            D = d;
        }

        public virtual new void MyFun02()
        {
            Console.WriteLine($"A : {A} , B : {B} , C : {C}  , D : {D}");
        }

         
    }


    class TypeE:TypeD
    {
        public int E { get; set; }

        public TypeE(int a, int b, int c, int d,int e):base(a,b,c,d)
        {
            E = e;
        }
        public override void MyFun02()
        {
            Console.WriteLine($"A : {A} , B : {B} , C : {C}  , D : {D} . E : {E}");

        }
    }
}
