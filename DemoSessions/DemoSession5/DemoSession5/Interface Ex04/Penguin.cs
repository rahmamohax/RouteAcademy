using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSession5.Interface_Ex04
{
    internal class Penguin : IBird
    {
        public void Eat()
        {
            throw new NotImplementedException();
        }

        //public void Fly()
        //{
        //    throw new NotImplementedException();
        //} 
        // Wrong Implementation, penguins dont fly

        public void Walk()
        {
            throw new NotImplementedException();
        }
    }
}
