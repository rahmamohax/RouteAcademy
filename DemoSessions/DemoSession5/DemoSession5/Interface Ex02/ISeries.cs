using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSession5.Interface_Ex02
{
    internal interface ISeries
    {
        public int Current { get; set; }

        public void GetNext();
        public void Reset();


    }
}
