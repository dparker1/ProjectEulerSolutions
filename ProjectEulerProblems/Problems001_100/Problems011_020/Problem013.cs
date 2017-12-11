using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProjectEulerProblems
{
    public class Problem013
    {
        public static string Solve()
        {
            string[] numbers = System.IO.File.ReadAllLines(@"..\..\txt\Problem013Text.txt");
            BigInteger result = BigInteger.Parse("0");
            foreach(string s in numbers)
            {
                result += BigInteger.Parse(s);
            }

            return result.ToString().Substring(0, 10);
        }
    }
}
