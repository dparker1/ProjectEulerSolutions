using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem120
    {
        public static long Solve()
        {
            return SolveFast();
        }

        private static long SolveSlow()
        {
            long sum = 0, r = 0;
            for(int a = 4; a <= 1000; a++)
            {
                int aSquared = a * a;
                long rMax = -1;
                for(int n = 1; ; n++)
                {
                    r = (EulerUtilities.ModularExponent(a - 1, n, aSquared) + EulerUtilities.ModularExponent(a + 1, n, aSquared)) % aSquared;
                    if(r == rMax)
                    {
                        sum += rMax;
                        break;
                    }
                    rMax = (r > rMax) ? r : rMax;
                }
            }
            return sum;
        }

        private static int SolveFast()
        {
            int sum = 0;
            for(int a = 3; a <= 1000; a++)
            {
                sum += 2 * a * ((a - 1) / 2);
            }
            return sum;
        }

        
    }
}
