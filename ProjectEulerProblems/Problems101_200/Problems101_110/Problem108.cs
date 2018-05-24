using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem108
    {
        public static int Solve()
        {
            List<int> primes = EulerUtilities.GeneratePrimes(20).ConvertAll(x => (int)x);
            for(int n = 1260; n < 1000000; n += 2)
            {
                if((Count(n, primes) + 1) / 2 > 1000)
                {
                    return n;
                }

            }
            return -1;
        }

        private static int Count(int n, List<int> primes)
        {
            int count = 1;
            int exp = 0;
            int r = n;
            for(int i = 0; i < primes.Count; i++)
            {
                if(primes[i] * primes[i] > n)
                {
                    return count * 2;
                }

                exp = 1;
                while(r % primes[i] == 0)
                {
                    exp += 2;
                    r /= primes[i];
                }
                count *= exp;

                if(r == 1)
                {
                    return count;
                }
            }
            return count;
        }

    }
}
