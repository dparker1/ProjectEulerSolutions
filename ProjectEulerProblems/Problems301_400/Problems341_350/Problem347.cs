using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem347
    {
        public static long Solve()
        {
            int limit = 10000000;
            long sum = 0;
            List<long> primes = EulerUtilities.GeneratePrimes(limit);
            for(int p = 0; p < primes.Count; p++)
            {
                for(int q = p + 1; q < primes.Count; q++)
                {
                    long pMul = primes[p];
                    long largest = 0;
                    if(primes[p] * primes[q] > limit)
                    {
                        break;
                    }
                    while(pMul * primes[q] <= limit)
                    {
                        long inter = pMul * primes[q];
                        while(inter <= limit)
                        {
                            if(inter > largest)
                            {
                                largest = inter;
                            }
                            inter *= primes[q];
                        }
                        pMul *= primes[p];
                    }
                    sum += largest;
                }
            }
            return sum;
        }
    }
}
