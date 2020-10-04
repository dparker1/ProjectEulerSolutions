using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem231
    {
        public static long Solve()
        {
            int n = 20000000;
            int r = 15000000;
            int n_r = n - r;
            List<long> primes = EulerUtilities.GeneratePrimes(20000000);
            long sum = 0;
            for (int p = 0; p < primes.Count; p++)
            {
                long prime = primes[p];
                while(prime < n)
                {
                    sum += primes[p] * (n / prime - r / prime - n_r / prime);
                    prime *= primes[p];
                }
            }
            return sum;
        }
    }
}
