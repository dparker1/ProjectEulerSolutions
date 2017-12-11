using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem050
    {
        public static int Solve()
        {
            List<long> primesLong = EulerUtilities.GeneratePrimes(1000000);
            List<int> primes = primesLong.ConvertAll(x => (int)x);
            int maxStreak = 1, maxPrime = 0;
            int currentStreak, current;
            for(int start = 0; start < primes.Count; start++)
            {
                currentStreak = 1;
                current = 0;
                for(int consec = start; consec < primes.Count; consec++)
                {
                    current += primes[consec];
                    if(current > 1000000)
                    {
                        break;
                    }
                    if(currentStreak > maxStreak && primes.Contains(current))
                    {
                        maxStreak = currentStreak;
                        maxPrime = current;
                    }
                    currentStreak++;
                }
            }
            return maxPrime;
        }
    }
}
