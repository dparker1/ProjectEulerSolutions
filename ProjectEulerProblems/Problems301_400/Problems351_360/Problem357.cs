using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem357
    {
        public static long Solve()
        {
            int limit = 100000000;
            bool[] isPrime = new bool[limit + 1];
            List<long> primes = EulerUtilities.GeneratePrimes(limit);
            foreach(long prime in primes)
            {
                isPrime[prime] = true;
            }
            //.Where(x => EulerUtilities.IsPrime(2 + (x / 2)))
            IEnumerable<long> primesLessOne = primes.ConvertAll(x => x - 1);
            long sum = 0;
            foreach(long primeLessOne in primesLessOne)
            {
                if(Check(primeLessOne, isPrime))
                {
                    sum += primeLessOne;
                }
            }
            return sum;
        }

        public static bool Check(long n, bool[] isPrime)
        {
            double sqrt = Math.Sqrt(n);
            for(int i = 2; i <= sqrt; i++)
            {
                if(n % i == 0)
                {
                    long s = i + n / i;
                    if(!isPrime[s])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
