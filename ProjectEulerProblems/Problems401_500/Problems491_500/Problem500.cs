using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProjectEulerProblems
{
    public class Problem500
    {
        public static long Solve()
        {
            List<long> primes = EulerUtilities.GeneratePrimes(7500000);
            SortedSet<long> sorted = new SortedSet<long>();
            for(int i = 0; i < 500500; i++)
            {
                sorted.Add(primes[i]);
            }
            long result = 1;
            long mod = 500500507;
            int divisorPower = 0;
            long x;
            while(divisorPower < 500500)
            {
                x = sorted.Min;
                result = (result * (x % mod)) % mod;
                sorted.Remove(x);
                sorted.Add(x * x);
                divisorPower++;
            }
            return result;
        }
    }
}
