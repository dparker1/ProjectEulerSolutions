using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem087
    {
        public static int Solve()
        {
            int goal = 50000000;
            int limit = (int)Math.Ceiling(Math.Sqrt(goal));
            List<int> primes = EulerUtilities.GeneratePrimes(limit).ConvertAll(x => (int)x);
            HashSet<int> results = new HashSet<int>();

            int soFar2, soFar3, soFar4;
            for(int squared = 0; squared < primes.Count; squared++)
            {
                soFar2 = (int)Math.Pow(primes[squared], 2);
                if(soFar2 > goal)
                {
                    break;
                }
                for(int cubed = 0; cubed < primes.Count; cubed++)
                {
                    soFar3 = soFar2 + (int)Math.Pow(primes[cubed], 3);
                    if(soFar3 > goal)
                    {
                        break;
                    }
                    for(int fourth = 0; fourth < primes.Count; fourth++)
                    {
                        soFar4 = soFar3 + (int)Math.Pow(primes[fourth], 4);
                        if(soFar4 > goal)
                        {
                            break;
                        }
                        else
                        {
                            results.Add(soFar4);
                        }
                    }
                }
            }

            return results.Count;

        }
    }
}
