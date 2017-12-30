using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem070
    {
        public static long Solve()
        {
            List<long> primes = EulerUtilities.GeneratePrimes(100000);
            primes.RemoveAll(x => (x < 1000 && x > 10000));
            double minRatio = double.MaxValue;
            long minNumber = 0;
            for(int i = 0; i < primes.Count; i++)
            {
                for(int j = i + 1; j < primes.Count; j++)
                {
                    long num = (primes[i] * primes[j]);
                    long totient = (primes[i] - 1) * (primes[j] - 1);
                    double ratio = ((double) num) / totient;
                    if(num > 10000000)
                    {
                        break;
                    }
                    if(ratio < minRatio && EulerUtilities.IsPermutation(num.ToString(), totient.ToString()))
                    {
                        minRatio = ratio;
                        minNumber = num;
                    }
                }
            }
            return minNumber;
        }
    }
}
