using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProjectEulerProblems
{
    public class Problem025
    {
        public static int Solve()
        {
            List<BigInteger> sequence = new List<BigInteger>();
            sequence.Add(new BigInteger(0));
            sequence.Add(new BigInteger(1));
            sequence.Add(new BigInteger(1));
            int index = 2;
            while(sequence[index].ToString().Length < 1000)
            {
                sequence.Add(sequence[index - 1] + sequence[index]);
                index++;
            }

            return index;
        }
    }
}
