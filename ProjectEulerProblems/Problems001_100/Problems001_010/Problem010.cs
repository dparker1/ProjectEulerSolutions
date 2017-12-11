using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem010
    {
        public static long Solve()
        {
            List<long> primes = EulerUtilities.GeneratePrimes(2000000);
            long sum = 0;
            foreach(long prime in primes)
            {
                sum += prime;
            }

            return sum;
        }
    }
}
