using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem381
    {
        public static long Solve()
        {
            List<long> primes = EulerUtilities.GeneratePrimes(100000000);
            primes.Remove(2);
            primes.Remove(3);
            long sum = 0;
            long n5, n4, n3, n2, n1;
            foreach(long p in primes)
            {
                n5 = EulerUtilities.ModFactorial(p - 5, p);
                n4 = ((p - 4) * n5) % p;
                n3 = ((p - 3) * n4) % p;
                n2 = 1;
                n1 = p - 1;
                sum += (n5 + n4 + n3 + n2 + n1) % p;
            }
            return sum;
        }

        
    }
}
