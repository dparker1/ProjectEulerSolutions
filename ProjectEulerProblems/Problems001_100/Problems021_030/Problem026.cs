using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem026
    {
        public static int Solve()
        {
            int length = 0;
            int i;
            for(i = 1000; i > 1; i--)
            {
                if(length >= i)
                {
                    break;
                }

                int[] remainders = new int[i];
                int numerator = 1;
                int position;

                for(position = 0; remainders[numerator] == 0 && numerator != 0; position++)
                {
                    remainders[numerator] = position;
                    numerator *= 10;
                    numerator %= i;
                }

                if(position - remainders[numerator] > length)
                {
                    length = position - remainders[numerator];
                }

            }
            return i + 1;
        }
    }
}
