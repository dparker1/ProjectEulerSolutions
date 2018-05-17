using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem123
    {
        public static long Solve()
        {
            List<long> primes = EulerUtilities.GeneratePrimes(1000000);
            long pSquared, r = 0;
            long limit = (long)Math.Pow(10, 10);
            int n;
            for(n = 7037; n < primes.Count; n+=2)
            {
                if(r > limit)
                {
                    break;
                }
                pSquared = primes[n] * primes[n];
                r = (EulerUtilities.ModularExponent(primes[n] - 1, n, pSquared) + EulerUtilities.ModularExponent(primes[n] + 1, n, pSquared)) % pSquared;

            }
            return n;
        }
    }
}
