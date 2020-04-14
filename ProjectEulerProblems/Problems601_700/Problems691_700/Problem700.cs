using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem700
    {
        public static string Solve()
        {
            long diff = 1504170715041707;
            long mod = 4503599627370517;
            long sum = 0;
            long high = diff;
            long low = diff;
            long next;
            while(low > 0)
            {
                next = (high + low) % mod;
                if(next < low)
                {
                    sum += low;
                    low = next;
                }
                else
                {
                    high = next;
                }
            }
            return sum.ToString();
        }
    }
}
