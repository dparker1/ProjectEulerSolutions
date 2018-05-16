using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem120
    {
        public static int Solve()
        {
            return SolveFast();
        }

        private static int SolveSlow()
        {
            int sum = 0, r = 0;
            for(int a = 4; a <= 1000; a++)
            {
                int aSquared = a * a;
                int rMax = -1;
                for(int n = 1; ; n++)
                {
                    r = (ModularExponent(a - 1, n, aSquared) + ModularExponent(a + 1, n, aSquared)) % aSquared;
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

        private static int ModularExponent(int b, int e, int mod)
        {
            int curr = 1, eCount = 0;
            while(eCount < e)
            {
                curr *= b;
                curr %= mod;
                eCount++;
            }
            return curr;
        }
    }
}
