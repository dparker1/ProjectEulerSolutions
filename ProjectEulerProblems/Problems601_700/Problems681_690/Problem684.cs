using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProjectEulerProblems
{
    public class Problem684
    {
        static BigInteger mod = 1000000007;
        public static string Solve()
        {
            BigInteger sum = 0;
            List<long> fibonacci = EulerUtilities.FibonacciLimit(90);
            fibonacci.RemoveAt(0);
            for(int i = 0; i < fibonacci.Count; i++)
            {
                sum = sum + S(fibonacci[i]);
                sum = sum % mod;
            }
            return sum.ToString();
        }

        public static BigInteger S(BigInteger n)
        {
            BigInteger a = n / 9;
            BigInteger b = n % 9;
            return 6*BigInteger.ModPow(10, a, mod) - (9 * a) % mod - 6 + b*(b+3)/2*BigInteger.ModPow(10, a, mod) - b;
        }
    }
}
