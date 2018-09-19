using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem549
    {
        public static long Solve()
        {
            int limit = 1000000;
            EulerUtilities.LoadPrimes(limit);
            bool[] isPrime = new bool[limit + 1];
            long sum = 0;
            foreach(long p in EulerUtilities.Primes)
            {
                isPrime[p] = true;
            }
            int m, factorial;
            for(int i = 2; i <= limit; i++)
            {
                if(isPrime[i])
                {
                    sum += i;
                    Console.WriteLine(i);
                }
                else
                {
                    m = 2;
                    factorial = 1;
                    while(factorial != 0)
                    {
                        factorial = (factorial * m) % i;
                        m++;
                    }
                    sum += m - 1;
                }
            }
            return sum;
        }

        private static Dictionary<long, int> AddFactors(Dictionary<long, int> a, Dictionary<long, int> b)
        {
            foreach(long key in b.Keys)
            {
                if(a.ContainsKey(key))
                {
                    a[key] += b[key];
                }
                else
                {
                    a[key] = b[key];
                } 
            }
            return a;
        }

        private static bool Divides()
        {
            return true;
        }
    }
}
