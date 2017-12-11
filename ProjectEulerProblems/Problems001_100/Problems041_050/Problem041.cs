using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem041
    {
        public static long Solve()
        {
            List<long> primes = EulerUtilities.GeneratePrimes(10000000);
            long largest = 0;
            string s;
            foreach(long prime in primes)
            {
                s = prime.ToString();
                if(prime > largest && IsPandigital(s, s.Length))
                {
                    largest = prime;
                }
            }

            return largest;
        }

        static bool IsPandigital(string num, int n)
        {
            for(int i = 1; i <= n; i++)
            {
                if(!num.Contains(i.ToString()))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
