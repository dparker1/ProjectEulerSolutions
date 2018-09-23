using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem204
    {
        static List<int> primes;
        public static int Solve()
        {
            int limit = 1000000000;
            primes = EulerUtilities.GeneratePrimes(100).ConvertAll(x => (int)x);
            return HammingCount(1, 0, limit);
        }

        static int HammingCount(long n, int start, int lim)
        {
            int count = 1;
            for(int i = start; i < primes.Count; i++)
            {
                long p = primes[i] * n;
                if(p > lim)
                {
                    break;
                }
                count += HammingCount(p, i, lim);
            }
            return count;
        }
    }
}
