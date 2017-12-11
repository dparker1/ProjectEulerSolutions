using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem049
    {
        public static string Solve()
        {
            List<long> primes = EulerUtilities.GeneratePrimes(10000);
            primes.RemoveAll(x => x < 1000);
            HashSet<string> permutationSet;
            foreach(long prime in primes)
            {
                permutationSet = new HashSet<string>(EulerUtilities.Permute(prime.ToString()));
                permutationSet.RemoveWhere(x => !primes.Contains(int.Parse(x)));
                if(permutationSet.Count > 2 && !permutationSet.Contains("1487"))
                {
                    for(int diff = 1; diff < 5000; diff++)
                    {
                        string one = (prime + diff).ToString();
                        string two = (prime + 2 * diff).ToString();
                        if(permutationSet.Contains(one) && permutationSet.Contains(two))
                        {
                            return prime + one + two;
                        }
                    }
                }
            }
            return "0";
        }
    }
}
