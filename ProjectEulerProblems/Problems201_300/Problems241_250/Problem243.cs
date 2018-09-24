using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem243
    {
        public static long Solve()
        {
            double goal = 15499.0 / 94744.0;
            List<int> primes = EulerUtilities.GeneratePrimes(100).ConvertAll(x => (int)x);
            EulerUtilities.LoadPrimes(100000000);
            long res = 1;
            for(int i = 0; i < primes.Count; i++)
            {
                res *= primes[i];
                if((double)EulerUtilities.TotientCount(res)/(res - 1) < goal)
                {
                    res /= primes[i];
                    break;
                }
            }
            for(int i = 1; ; i++)
            {
                long r = res * i;
                if((double)EulerUtilities.TotientCount(r) / (r - 1) < goal)
                {
                    return r;
                }
            }
            return 0;
        }
    }
}
