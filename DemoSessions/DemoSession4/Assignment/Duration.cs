using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class Duration
    {

        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        #region Constructors
        private Duration()
        {
            
        }
        public Duration(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }
        public Duration(int total)
        {
            Hours = total / 3600;
            total %= 3600;
            Minutes = total / 60;
            Seconds = total % 60;
            Normalize();
        } 
        #endregion

        private void Normalize()
        {
            if (Seconds <= 60)
            {
                Minutes += Seconds/ 60;
                Seconds %= 60;
            }
            if (Minutes <= 60)
            {
                Hours += Minutes / 60;
                Minutes %= 60;
            }
            if (Seconds < 0 || Minutes < 0 || Hours < 0)
            {
                Hours = Minutes = Seconds = 0; // Clamp to zero if invalid
            }
        }

        #region Operator Overriding
        public int ToSeconds()
        {
            return (Hours * 3600) + (Minutes * 60) + Seconds;
        }

        //D3 = D1 + D2
        public static Duration operator +(Duration d1, Duration d2)
        {
            return new Duration((d1?.Hours?? 0) + (d2?.Hours?? 0),( d1?.Minutes?? 0) + (d2?.Minutes?? 0), (d1?.Seconds?? 0) + (d2?.Seconds??0));
        }

        //D3 = D1 + 7800
        public static Duration operator +(Duration d1, int total)
        {
            Duration totalTime = new Duration(total);
            return new Duration((d1?.Hours ?? 0) + (totalTime?.Hours ?? 0), (d1?.Minutes ?? 0) + (totalTime?.Minutes ?? 0), (d1?.Seconds ?? 0) + (totalTime?.Seconds ?? 0));
        }
        //D3 = 666 + D3
        public static Duration operator +(int total, Duration d1)
        {
            Duration totalTime = new Duration(total);
            return new Duration((d1?.Hours ?? 0) + (totalTime?.Hours ?? 0), (d1?.Minutes ?? 0) + (totalTime?.Minutes ?? 0), (d1?.Seconds ?? 0) + (totalTime?.Seconds ?? 0));
        }

        //D3 = ++D1  //(Increase One Minute)
        public static Duration operator ++(Duration d)
        {
            return new Duration()
            {
                Hours = d?.Hours?? 0,
                Minutes= (d?.Minutes?? 0) +1,
                Seconds = (d?.Seconds?? 0)
            };
        }

        //D3 = --D2  //(Decrease One Minute)
        public static Duration operator --(Duration d)
        {
            return new Duration()
            {
                Hours = d?.Hours ?? 0,
                Minutes = (d?.Minutes ?? 0) - 1,
                Seconds = (d?.Seconds ?? 0)
            };
        }

        //D1 = D1 - D2
        public static Duration operator -(Duration d1, Duration d2)
        {
            return new Duration((d1?.Hours ?? 0) - (d2?.Hours ?? 0), (d1?.Minutes ?? 0) - (d2?.Minutes ?? 0), (d1?.Seconds ?? 0) - (d2?.Seconds ?? 0));
        }

        //If(D1 > D2)
        public static bool operator >(Duration left, Duration right)
        {
            if(left.Hours == right.Hours)
                if(left.Minutes == right.Minutes)
                    return left.Seconds > right.Seconds;
                else return left.Minutes > right.Minutes;

            return left.Hours > right.Hours;

        }

        public static bool operator <(Duration left, Duration right)
        {
            if (left.Hours == right.Hours)
                if (left.Minutes == right.Minutes)
                    return left.Seconds < right.Seconds;
                else return left.Minutes < right.Minutes;

            return left.Hours < right.Hours;

        }
        //If(D1 <= D2)

        //If(D1)
        //DateTime Obj = (DateTime)D1

        #endregion
        public override string ToString()
        {
            return $"Hours: {Hours}, Minutes: {Minutes}, Seconds: {Seconds}";
        }
    }
}
