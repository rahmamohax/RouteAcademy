using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmnet
{
    class Date
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public Date(int day, int month, int year)
        {
            if (day <= 0 || day > 31) throw new ArgumentException("Invalid day.");
            if (month <= 0 || month > 12) throw new ArgumentException("Invalid month.");
            if (year < 1900 || year > DateTime.Now.Year) throw new ArgumentException("Invalid year.");

            Day = day;
            Month = month;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Day:D2}/{Month:D2}/{Year}";
        }
    }
}
