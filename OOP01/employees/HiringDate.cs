using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employees
{
    
    public struct HiringDate
    {
        public int day;
        public int month;
        public int year;

        public HiringDate(int _day, int _month, int _year)
        {
            day= _day;
            month= _month;
            year= _year;
        }

        public override string ToString()
        {
            return $"{day:D2}/{month:D2}/{year}";
        }
    }
}
