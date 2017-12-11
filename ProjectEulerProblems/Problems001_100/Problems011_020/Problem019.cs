using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem019
    {
        public static int Solve()
        {
            int year = 1901, month = 0, dayOfWeek = 2; //Sunday = 0, Saturday = 6
            int[] monthDurations = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int result = 0;

            while(year != 2001)
            {
                dayOfWeek = (dayOfWeek + monthDurations[month]) % 7;
                month++;
                if(month % 12 == 0)
                {
                    month -= 12;
                    year++;
                }
                if(dayOfWeek == 0)
                {
                    result++;
                }

            }

            return result;
        }
    }
}
