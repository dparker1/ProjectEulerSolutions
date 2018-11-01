using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProjectEulerProblems
{
    public class Problem113
    {
        public static string Solve()
        {
            BigInteger count = 0;
            int expBound = 100;
            int digits = 9;
            BigInteger increasing = Factorial(expBound + digits) / (Factorial(expBound) * Factorial(digits)) - 1;
            BigInteger decreasing = Factorial(expBound + digits + 1) / (Factorial(expBound) * Factorial(digits + 1)) - 1;
            BigInteger repeating = 10 * expBound;
            count = increasing + decreasing - repeating;
            return count.ToString();
        }

        public static BigInteger Factorial(BigInteger n)
        {
            BigInteger res = 1;
            while(n > 1)
            {
                res *= n;
                n--;
            }
            return res;
        }
    }
}
