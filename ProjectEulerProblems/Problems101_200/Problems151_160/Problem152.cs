using Microsoft.SolverFoundation.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem152
    {
        static int limit = 40;
        static Rational[] values, remainders;
        public static int Solve()
        {
            values = new Rational[limit + 1];
            remainders = new Rational[limit + 1];
            for(int i = 2; i <= limit; i++)
            {
                values[i] = i * i;
                values[i] = 1 / values[i];
                remainders[1] += values[i];
            }
            for(int i = 2; i <= limit; i++)
            {
                remainders[i] = remainders[i - 1] - values[i];
            }
            int result = 0;
            f(0.5, values[2], 2, ref result);
            return result;
        }

        public static void f(Rational a, Rational curr, int pos, ref int result)
        {
            if(curr > a)
            {
                return;
            }
            if(curr == a)
            {
                result++;
                return;
            }

            for(int i = pos + 1; i <= limit; i++)
            {
                if(curr + remainders[i] < a)
                {
                    break;
                }
                if(curr + remainders[i] == a)
                {
                    result++;
                    break;
                }
                f(a, curr + values[i], i, ref result);
            }

            return;
        }
    }
}
