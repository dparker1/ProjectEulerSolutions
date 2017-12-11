using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem060
    {
        public static long Solve()
        {
            long minSum = long.MaxValue;
            List<long> primes = EulerUtilities.GeneratePrimes(10000);
            HashSet<long>[] pairs = new HashSet<long>[primes.Count];
            primes.Remove(2);
            for(int prime1 = 0; prime1 < primes.Count; prime1++)
            {
                if(pairs[prime1] == null)
                {
                    pairs[prime1] = MakePairs(prime1, primes);
                }
                for(int prime2 = prime1 + 1; prime2 < primes.Count; prime2++)
                {
                    if(pairs[prime2] == null)
                    {
                        pairs[prime2] = MakePairs(prime2, primes);
                    }
                    if(!pairs[prime1].Contains(primes[prime2]))
                    {
                        continue;
                    }
                    for(int prime3 = prime2 + 1; prime3 < primes.Count; prime3++)
                    {
                        if(pairs[prime3] == null)
                        {
                            pairs[prime3] = MakePairs(prime3, primes);
                        }
                        if(!pairs[prime1].Contains(primes[prime3]) || !pairs[prime2].Contains(primes[prime3]))
                        {
                            continue;
                        }
                        for(int prime4 = prime3 + 1; prime4 < primes.Count; prime4++)
                        {
                            if(pairs[prime4] == null)
                            {
                                pairs[prime4] = MakePairs(prime4, primes);
                            }
                            if(!pairs[prime1].Contains(primes[prime4]) || !pairs[prime2].Contains(primes[prime4]) || !pairs[prime3].Contains(primes[prime4]))
                            {
                                continue;
                            }
                            for(int prime5 = prime4 + 1; prime5 < primes.Count; prime5++)
                            {
                                if(!pairs[prime1].Contains(primes[prime5]) || !pairs[prime2].Contains(primes[prime5]) || !pairs[prime3].Contains(primes[prime5]) || !pairs[prime4].Contains(primes[prime5]))
                                {
                                    continue;
                                }
                                long newSum = primes[prime1] + primes[prime2] + primes[prime3] + primes[prime4] + primes[prime5];
                                if(minSum > newSum)
                                {
                                    minSum = newSum;
                                }
                            }
                        }
                    }
                }
            }

            return minSum;
        }

        public static HashSet<long> MakePairs(int a, List<long> primes)
        {
            HashSet<long> pairs = new HashSet<long>();
            for(int b = a + 1; b < primes.Count; b++)
            {
                if(EulerUtilities.IsPrime(long.Parse(primes[a]+""+primes[b])) && EulerUtilities.IsPrime(long.Parse(primes[b] + "" + primes[a])))
                {
                    pairs.Add(primes[b]);
                }
            }
            return pairs;
        }
    }
}
