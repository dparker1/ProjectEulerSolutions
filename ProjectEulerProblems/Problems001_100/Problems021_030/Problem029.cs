using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProjectEulerProblems
{
    public class Problem029
    {
        public static int Solve()
        {
            SortedSet<BigInteger> numbers = new SortedSet<BigInteger>();
            BigInteger result;
            for(int a = 2; a <= 100; a++)
            {
                for(int b = 2; b <= 100; b++)
                {
                    result = BigInteger.Pow(new BigInteger(a), b);
                    numbers.Add(result);
                }
            }

            return numbers.Count;
        }
    }
}
