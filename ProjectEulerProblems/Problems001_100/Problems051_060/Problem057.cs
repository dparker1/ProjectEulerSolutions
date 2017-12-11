using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProjectEulerProblems
{
    public class Problem057
    {
        public static int Solve()
        {
            int limit = 1000;
            BigInteger[] numerators = new BigInteger[limit];
            BigInteger[] denominators = new BigInteger[limit];

            numerators[0] = 3;
            denominators[0] = 2;
            int count = 0;

            for(int index = 1; index < limit; index++)
            {
                denominators[index] = numerators[index - 1] + denominators[index - 1];
                numerators[index] = denominators[index] + denominators[index - 1];
                if(numerators[index].ToString().Length > denominators[index].ToString().Length)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
