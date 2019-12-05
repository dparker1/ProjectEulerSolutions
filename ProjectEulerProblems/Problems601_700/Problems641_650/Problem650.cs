using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProjectEulerProblems
{
    public class Problem650
    {
        public static string Solve()
        {
            EulerUtilities.LoadPrimesSmall(20000);
            long mod = 1000000007;
            Dictionary<int, Dictionary<int, int>> cachedFactors = cache(20000);
            long sum = 4;
            for(int n = 3; n <= 100; n++)
            {
                Dictionary<int, int> primeFactors = new Dictionary<int, int>();
                Dictionary<int, int> primeRunning = new Dictionary<int, int>();
                for(int k = 0; k < n / 2; k++)
                {
                    foreach(KeyValuePair<int, int> x in cachedFactors[n - k])
                    {
                        if(primeRunning.ContainsKey(x.Key))
                        {
                            primeRunning[x.Key] += x.Value;
                        }
                        else
                        {
                            primeRunning.Add(x.Key, x.Value);
                        }
                    }

                    foreach(KeyValuePair<int, int> x in cachedFactors[k + 1])
                    {
                        primeRunning[x.Key] -= x.Value;
                    }

                    foreach(KeyValuePair<int, int> x in primeRunning)
                    {
                        if(primeFactors.ContainsKey(x.Key))
                        {
                            primeFactors[x.Key] += 2 * x.Value;
                        }
                        else
                        {
                            primeFactors.Add(x.Key, 2 * x.Value);
                        }
                    }
                }
                
                if(n % 2 == 0)
                {
                    int k = n / 2 - 1;
                    foreach(KeyValuePair<int, int> x in primeRunning)
                    {
                        primeFactors[x.Key] -= x.Value;
                    }
                }

                long sSum = 1;
                foreach(KeyValuePair<int, int> x in primeFactors)
                {
                    long s = 0;
                    for(int i = 0; i <= x.Value; i++)
                    {
                        s += EulerUtilities.ModularExponent(x.Key, i, mod);
                    }
                    sSum = (sSum * s) % mod;
                }
                sum = (sSum + sum) % mod;
            }
            return sum.ToString();

        }

        public static Dictionary<int, Dictionary<int, int>> cache(int n)
        {
            var d = new Dictionary<int, Dictionary<int, int>>();
            for(int i = 1; i <= n; i++)
            {
                d.Add(i, EulerUtilities.PrimeFactorsWithCount(i));
            }
            return d;
        }
    }
}
