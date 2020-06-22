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
        static BigInteger modLessDiv = ((mod - 1) / 2);
        static BigInteger[] speed = new BigInteger[19];
        public static string Solve()
        {
            BigInteger sum = 0;
            speed[0] = 1;
            for(int i = 1; i < 19; i++)
            {
                speed[i] = BigInteger.ModPow(10, i, mod);
            }
            List<long> fibonacci = EulerUtilities.FibonacciLimit(91);
            fibonacci.RemoveAt(0);
            for(int i = 0; i < fibonacci.Count; i++)
            {
                sum += S(fibonacci[i]);
                sum = sum % mod;

            }
            return sum.ToString();
        }

        public static BigInteger S(BigInteger n)
        {
            BigInteger b = n / 9;
            BigInteger a = n % 9;
            int r = (int)(b % 18);
            BigInteger c = (b / 18) % (modLessDiv);
            BigInteger d = BigInteger.ModPow(49, c, mod);
            Console.WriteLine(d);
            d = (d * speed[r]) % mod;
            BigInteger S = d * (a + 6 + (a * (1 + a) / 2)) - (a + 9 * b + 6);
            return S % mod;
        }
    }
}
