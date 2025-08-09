using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSession6.Abstraction
{
    //Abstract Class: a Container for common code for other classes
    //Common Code -> [Fully Implemented Members(eg. Dim01) + Abstract Members]
    internal abstract class Shape
    {
        //Ctor of an Abstracted Class is Unreachable, but its used to help implementing its children 
        protected Shape(decimal dim01, decimal dim02)
        {
            Dim01 = dim01;
            Dim02 = dim02;
        }

        public decimal Dim01 { get; set; }
        public decimal Dim02 { get; set; }
        public abstract decimal Perimeter { get; }     //not fully implemented, yet

        //An Abstract method is Implicitly a Virtual Method
        public abstract decimal CalcArea();                 //not fully implemented, yet
    }

    //Concreate Class: Fully Implemented Class

    interface I2DDraw
    {
        void Draw();
    }
    interface I3DDraw
    {
        void Draw();
    }
    abstract class RecBase : Shape
    {
        protected RecBase(decimal dim01, decimal dim02) : base(dim01, dim02)
        {
        }

        public override decimal CalcArea()
        {
            return Dim01 * Dim02;
        }
    }
    class Rectangle : RecBase   //Shape -> //Inherits + Implements class Shape
    {
        public Rectangle(decimal dim01, decimal dim02) : base(dim01, dim02)
        {
        }

        public override decimal Perimeter { 
            get { return Dim01 * Dim02 * 2; }  
        }
    }

    class Square : RecBase, I2DDraw, I3DDraw
    {
        public override decimal Perimeter => Dim01 * 4;

        public Square(decimal side) :base(side, side)
        {
            //Dim01 = Dim02 = side;
        }
        void I2DDraw.Draw()
        {
            throw new NotImplementedException();
        }

        void I3DDraw.Draw()
        {
            throw new NotImplementedException();
        }

    }

    class Circle : Shape
    {
        public Circle(decimal Radius) : base(Radius, Radius) 
        {
            //Dim01=Dim02=Radius;
        }
        public override decimal Perimeter => 2 * (decimal)Math.PI * Dim02;

        public override decimal CalcArea()
        {
            return (decimal)Math.PI * Dim02 * Dim02;
        }
    }

    class Triangle : Shape
    {
        public decimal Dim03 { get; set; }

        public Triangle(decimal dim01, decimal dim02, decimal dim03): base(dim01, dim02)
        {
            Dim03 = dim03;  
        }
        public override decimal Perimeter => throw new NotImplementedException();

        public override decimal CalcArea()
        {
            throw new NotImplementedException();
        }
    }
}
