using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem230
    {
        public static string Solve()
        {
            int length = 100;
            string A = "1415926535897932384626433832795028841971693993751058209749445923078164062862089986280348253421170679";
            string B = "8214808651328230664709384460955058223172535940812848111745028410270193852110555964462294895493038196";
            string[] strs = new string[] { B, A };

            List<long> fib = EulerUtilities.Fibonacci(Generator(17));
            string result = "";
            for(int i = 0; i <= 17; i++)
            {
                long index = Generator(i);
                long target = (index - 1) / length;
                int f = FirstAbove(target, fib) + 2;
                int a = (int)AorB(fib[f] - target);
                result = StringAccess(strs[a], (int)(index % length - 1)) + result;
            }
            return result;
            
        }

        private static long AorB(long n)
        {
            return 2 + (long)Math.Floor(n * EulerUtilities.GoldenRatio) - (long)Math.Floor((n + 1) * EulerUtilities.GoldenRatio);
        }

        private static long Generator(long n)
        {
            return (long)Math.Pow(7, n) * (127 + 19 * n);
        }

        private static int FirstAbove(long n, List<long> l)
        {
            for(int i = 0; i < l.Count; i++)
            {
                if(l[i] >= n)
                {
                    return i;
                }
            }
            return -1;
        }

        private static char StringAccess(string s, int i)
        {
            while(i < 0)
            {
                i += s.Length;
            }
            return s[i % s.Length];
        }
    }
}
