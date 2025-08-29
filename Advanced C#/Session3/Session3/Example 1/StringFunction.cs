using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session3.Example_1
{
    internal class StringFunction
    {
        public static int GetCountOfUpperChar(string? str)
        {
            int count = 0;
            if (!string.IsNullOrWhiteSpace(str))
                for (int i = 0; i < str.Length; i++)
                    if (char.IsUpper(str[i])) count++;

            return count;
        }
        public static int GetCountOfLowerChar(string? str)
        {
            int count = 0;
            if (!string.IsNullOrWhiteSpace(str))
                for (int i = 0; i < str.Length; i++)
                    if (char.IsLower(str[i])) count++;

            return count;
        }
    }
}
