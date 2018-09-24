using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem123
    {
        public static int Solve()
        {
            List<long> primes = EulerUtilities.GeneratePrimes(1000000);
            long r = 0;
            long limit = (long)Math.Pow(10, 10);
            for(int n = 1; n < primes.Count; n+=2)
            {
                r = 2 * n * primes[n - 1];
                if(r > limit)
                {
                    return n;
                }
            }
            return 0;
        }
    }
}
