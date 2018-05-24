using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem203
    {
        public static long Solve()
        {
            long[][] pascal = EulerUtilities.GetPascalsTriangle(50);
            HashSet<long> u = new HashSet<long>();
            List<long> primes = EulerUtilities.GeneratePrimes(10000);
            for(int i = 0; i < primes.Count; i++)
            {
                primes[i] *= primes[i];
            }
            for(int i = 0; i < pascal.Length; i++)
            {
                for(int j = 0; j < pascal[i].Length; j++)
                {
                    u.Add(pascal[i][j]);
                }
            }
            List<long> uniques = u.ToList();
            for(int i = 0; i < uniques.Count; i++)
            {
                foreach(long prime in primes)
                {
                    if(prime > uniques[i])
                    {
                        break;
                    }
                    if(uniques[i] % prime == 0)
                    {
                        u.Remove(uniques[i]);
                        break;
                    }
                }
            }
            return u.Sum();
        }
    }
}
