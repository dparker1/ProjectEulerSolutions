using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProjectEulerProblems
{
    public class Problem016
    {
        public static int Solve()
        {
            string s = (new BigInteger(2) ^ 1000).ToString();
            int sum = 0;
            foreach(char c in s)
            {
                sum += (int) char.GetNumericValue(c);
            }

            return sum;
        }
    }
}
