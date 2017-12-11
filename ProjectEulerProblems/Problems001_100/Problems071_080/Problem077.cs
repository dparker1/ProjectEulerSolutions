using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem077
    {
        public static int Solve()
        {
            List<int> primes = EulerUtilities.GeneratePrimes(1000000).ConvertAll(x => (int) x);
            int[] ways;
            int[] tempPrimes;
            for(int i = 10; i < Int32.MaxValue; i++)
            {
                tempPrimes = primes.Where(x => x <= i).ToArray();
                ways = new int[i + 1];
                ways[0] = 1;
                for(int prime = 0; prime < tempPrimes.Length; prime++)
                {
                    for(int way = tempPrimes[prime]; way <= i; way++)
                    {
                        ways[way] += ways[way - tempPrimes[prime]];
                    }
                }
                if(ways[i] > 5000)
                {
                    return i;
                }

            }
            return 0;
        }
    }
}
