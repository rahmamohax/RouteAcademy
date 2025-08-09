using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSession6.Static
{

    //Static readonly attribute: can be initialized at decleration or in static ctor (can't be re-assigned after)
    //Const attribute= must be initialized at decleration (can't be re-assigned after)

    //Static Ctor => Special ctor used to initialize static members
    //            => always private (cant be called explicitly)
    internal /*static*/ class Utility
        //Static Class => Cant be instantiated (cant create an object)
        //             => Can onlu contain static members and constant
        //             => No Ctors (but cat have static Ctor)
    {

        //public int X { get; set; }
        //public int Y { get; set; }

        public /*static*/ readonly double pi;
        //const double PI=3.14;

        static Utility()
        {
            //Used to initialize static fields
            //pi = 3.14; //valid
        }
        //public Utility(int x, int y)
        //{
        //    X = x;
        //    Y = y;
        //}

        public /*static*/ double MetertoCm(double value)
        {
            return value * 100;
        }
    }
}
