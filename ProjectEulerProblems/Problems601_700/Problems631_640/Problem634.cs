using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem634
    {
        public static long Solve()
        {
            long limit = 9 * (long)Math.Pow(10, 18);
            int cubeBound = (int)Math.Pow(limit, 1.0 / 3);
            List<long> primes = EulerUtilities.GeneratePrimes(cubeBound);
            long result = 0;

            for(long i = 2; i <= cubeBound; i++)
            {
                long cube = i * i * i;
                long squareBound = (long)Math.Sqrt(limit / cube);
                result += squareBound - 1;
            }

            return result;
        }
    }
}
