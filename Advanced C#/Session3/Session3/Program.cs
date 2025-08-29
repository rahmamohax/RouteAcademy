using Session3.Example_1;

namespace Session3
{
    class Program
    {
        //Delegates: a type that represents refreneces to methods
        public delegate int StringFuncDelegate(string? s);
        //new Delegate (class)
        //Reference from this delegate can refer to:
        //one or more function (pointer)
        //fuction must match the signature of delegate (parameter list - return type)

        public static void Main(string[] args)
        {
            #region Example 1
            //Step 01. Decleare Reference from delegate
            //Step 02. Initialize reference => point to a function

            //StringFuncDelegate stringFunc = new StringFuncDelegate(StringFunction.GetCountOfUpperChar);
            //StringFuncDelegate stringFunc = StringFunction.GetCountOfUpperChar; //Syntax Sugar

            //stringFunc += StringFunction.GetCountOfLowerChar; // Add New Reference for function

            //stringFunc -= StringFunction.GetCountOfUpperChar;

            //Step 03. Use Delegate Reference to [Call [Invoke] Method]

            //int? res = stringFunc?.Invoke("RoUtE");
            //if (stringFunc is not null)
            //{
            //    int res = stringFunc("RoUtE"); //Syntax Sugar
            //    Console.WriteLine(res);
            //}    
            #endregion


        }
    }
}