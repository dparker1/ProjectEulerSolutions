using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem006
    {
        public static int Solve(int low, int high)
        {
            int squareSums = (int) Math.Pow(EulerUtilities.SumRange(low, high), 2);
            int sumSquares = 0;
            for(int i = low; i <= high; i++)
            {
                sumSquares += (int) Math.Pow(i, 2);
            }

            return squareSums - sumSquares;
        }
    }
}
