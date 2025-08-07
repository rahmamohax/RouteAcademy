using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class Rectangle : IRectangle
    {

        public int Width { get; }
        public int Height { get; }

        public double Area {
            get { return Width * Height; }
        }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public void DisplayShapeInfo()
        {
            Console.WriteLine("Shape: Rectangle");
            Console.WriteLine($"Width: {Width}");
            Console.WriteLine($"Height: {Height}");
            Console.WriteLine($"Area: {Area:F2}");
            Console.WriteLine();
        }
    }
}
