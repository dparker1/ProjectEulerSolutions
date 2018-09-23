using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem188
    {
        public static long Solve()
        {
            long mod = 100000000;
            long k = 1855;
            long n = 1777;
            long power = EulerUtilities.ModularExponent(n, n, mod);
            k--;
            while(k > 1)
            {
                power = EulerUtilities.ModularExponent(n, power, mod);
                k--;
            }
            return power;
        }
    }
}
