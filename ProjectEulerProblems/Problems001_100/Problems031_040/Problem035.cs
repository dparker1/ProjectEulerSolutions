using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem035
    {
        public static int Solve()
        {
            int circularCount = 0;
            List<long> primes = EulerUtilities.GeneratePrimes(1000000);
            List<string> circulation;
            foreach(long prime in primes)
            {
                circulation = EulerUtilities.Circulate(prime.ToString());
                if(IsCircularPrime(circulation))
                {
                    circularCount++;
                }
            }
            return circularCount;
        }

        public static bool IsCircularPrime(List<string> circulations)
        {
            bool success = true;
            foreach(string s in circulations)
            {
                if(!EulerUtilities.IsPrime(long.Parse(s)))
                {
                    success = false;
                    break;
                }
            }
            return success;
        }
    }
}
