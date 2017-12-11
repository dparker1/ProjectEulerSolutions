using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProjectEulerProblems
{
    public class Problem048
    {
        public static string Solve()
        {
            BigInteger result = new BigInteger(0);
            BigInteger temp;
            for(int i = 1; i < 1000; i++)
            {
                temp = new BigInteger(i);
                result += BigInteger.Pow(temp, i);
            }
            string resultString = result.ToString();
            return resultString.Substring(resultString.Length - 10);
        }
    }
}
