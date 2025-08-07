using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal interface IRectangle : IShape
    {
        int Width { get;  }
        int Height { get;}

    }
} 
