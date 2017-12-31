using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem100
    {
        public static string Solve()
        {
            BigInteger b = BigInteger.Parse("15");
            BigInteger n = BigInteger.Parse("21");
            BigInteger max = BigInteger.Parse("1000000000000");
            while(n < max)
            {
                BigInteger b1 = 3 * b + 2 * n - 2;
                BigInteger n1 = 4 * b + 3 * n - 3;
                b = b1;
                n = n1;
            }
            return b.ToString();
        }
    }
}
