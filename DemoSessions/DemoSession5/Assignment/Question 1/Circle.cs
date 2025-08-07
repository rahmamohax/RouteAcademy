using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class Circle : ICircle
    {
        public double Radius { get ; set; }

        public double Area
        {
            get { return Radius * Radius * Math.PI; }
        }

        public Circle(double raduis)
        {
            Radius = raduis;
        }


        public void DisplayShapeInfo()
        {
            Console.WriteLine("Shape: Circle");
            Console.WriteLine($"Radius: {Radius}");
            Console.WriteLine($"Area: {Area:F2}");
            Console.WriteLine();
        }
    }
}
