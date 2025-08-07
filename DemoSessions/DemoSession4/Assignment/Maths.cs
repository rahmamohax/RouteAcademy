using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class Maths
    {
        public static int Add(int x, int y) { return x + y; }
        public static double Add(double x, double y) { return x + y; }
        public static float Add(float x, float y) { return x + y; }
        public static long Add(long x, long y) { return x + y; }

        public static int Subtract(int x, int y) { return x - y; }
        public static double Subtract(double x, double y) { return x - y; }
        public static float Subtract(float x, float y) { return x - y; }
        public static long Subtract(long x, long y) { return x - y; }

        public static long Multiply(int x, int y) { return x * y; }
        public static double Multiply(double x, double y) { return x * y; }
        public static double Multiply(float x, float y) { return x * y; }
        public static long Multiply(long x, long y) { return x * y; }

        public static double Divide(int x, int y) { return x /(double) y; }
        public static double Divide(double x, double y) { return x / y; }
        public static float Divide(float x, float y) { return x / y; }
        public static double Divide(long x, long y) { return x /(double) y; }
        


    }
}
