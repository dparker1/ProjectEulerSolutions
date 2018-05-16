using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem119
    {
        public static long Solve()
        {
            SortedList<long, long> sequence = new SortedList<long, long>();
            long n;
            for(int b = 2; b < 100; b++)
            {
                for(int e = 2; e < 10; e++)
                {
                    n = (long)Math.Pow(b, e);
                    if(DigitSum(n) == b)
                    {
                        sequence.Add(n, n);
                    }
                }
            }
            return sequence.Values[29];
        }

        private static long DigitSum(long n)
        {
            long s = 0;
            while(n != 0)
            {
                s += n % 10;
                n /= 10;
            }
            return s;
        }
    }
}
