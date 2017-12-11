using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem037
    {
        public static long Solve()
        {
            long sum = 0;
            List<long> primes = EulerUtilities.GeneratePrimes(1000000);
            for(int i = 0; i < primes.Count; i++)
            {
                if(primes[i] / 10 == 0)
                {
                    continue;
                }
                if(IsTruncatableLeft(primes[i]) && IsTruncatableRight(primes[i]))
                {
                    sum += primes[i];
                }
            }

            return sum;
        }

        public static bool IsTruncatableLeft(long i)
        {
            string s = i.ToString();
            while(s.Length > 1)
            {
                s = s.Substring(1, s.Length - 1);
                if(!EulerUtilities.IsPrime(long.Parse(s)))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsTruncatableRight(long i)
        {
            string s = i.ToString();
            while(s.Length > 1)
            {
                s = s.Substring(0, s.Length - 1);
                if(!EulerUtilities.IsPrime(long.Parse(s)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
