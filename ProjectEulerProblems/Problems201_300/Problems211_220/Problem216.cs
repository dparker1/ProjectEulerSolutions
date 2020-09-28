using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem216
    {
        public static int Solve()
        {
            int limit = 5000000;
            List<int> primes = EulerUtilities.GeneratePrimesSmall(2 * limit);
            int count = 0;
            for(long n = 2; n <= limit; n++)
            {
                long val = 2 * n * n - 1;

                int bound = (int)Math.Sqrt(val);
                int i = 1;
                int prime = primes[i];
                bool isPrime = true;
                while(prime <= bound)
                {
                    if(val % prime == 0)
                    {
                        isPrime = false;
                        break;
                    }
                    i++;
                    prime = primes[i];
                }
                if(isPrime)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
