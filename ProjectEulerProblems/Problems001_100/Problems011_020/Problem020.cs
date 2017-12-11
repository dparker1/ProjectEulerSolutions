using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProjectEulerProblems
{
    public class Problem020
    {
        public static int Solve()
        {
            BigInteger a = new BigInteger(1);
            for(int i = 100; i >= 2; i--)
            {
                a *= new BigInteger(i);
            }
            int result = 0;
            foreach(char c in a.ToString())
            {
                result += (int) char.GetNumericValue(c);
            }
            return result;
        }
    }
}
