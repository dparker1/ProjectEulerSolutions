using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem443
    {
        public static long Solve()
        {
            long gcd = 13;
            for(long n = 5; n <= Math.Pow(10, 3); n++)
            {
                Console.WriteLine((n - 1) + ": " + gcd + " | " + (double) gcd / (n-1));
                gcd += EulerUtilities.GreatestCommonDivisorBinary(gcd, n);
            }
            return gcd;
        }
    }
}
