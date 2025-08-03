using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSession4OOP.OperatorOverloading
{
    internal class Complex
    {
        public int Real { get; set; }
        public int Imag { get; set; }

        public override string ToString()
        {
            return $"Real : {Real} , Imag : {Imag} i";
        }

        #region Operators Overloading 
        //Must Be Non-Private  Class Member Method {static}

        #region Binary Operators
        public static Complex operator +(Complex left, Complex right)
        {
            return new Complex
            {
                Real = (left?.Real ?? 0) + (right?.Real ?? 0),
                Imag = (left?.Imag ?? 0) + (right?.Imag ?? 0)
            };
        }

        public static Complex operator -(Complex left, Complex right)
        {
            return new Complex
            {
                Real = (left?.Real ?? 0) - (right?.Real ?? 0),
                Imag = (left?.Imag ?? 0) - (right?.Imag ?? 0)
            };
        }
        #endregion

        #region Unary Operators

        public static Complex operator ++(Complex complex)
        {
            return new Complex()
            {
                Real = (complex?.Real ?? 0) + 1,
                Imag = (complex?.Imag ?? 0)

            };
        }

        public static Complex operator --(Complex complex)
        {
            return new Complex()
            {
                Real = (complex?.Real ?? 0) - 1,
                Imag = (complex?.Imag ?? 0)

            };
        }

        #endregion

        #region Comparison Operators


        public static bool operator > (Complex left, Complex right)
        {
            if (left?.Real == right?.Real)
                return left?.Imag > right?.Imag;
            else
                return left?.Real > right?.Real;
        }

        public static bool operator <(Complex left, Complex right)
        {
            if (left?.Real == right?.Real)
                return left?.Imag < right?.Imag;
            else
                return left?.Real < right?.Real;
        }
        #endregion





        #endregion
        #region Casting Operators Overloading

        public static /*int*/  explicit operator int (Complex complex)
        {
            return complex?.Real ?? 0;
        }
        public static /*string*/ implicit operator string(Complex complex) { 
        
           return complex?.ToString() ?? string.Empty;
        }
        #endregion
    }
}
