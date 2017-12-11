using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem044
    {
        public static long Solve()
        {
            List<long> pentas = new List<long>();
            pentas.Add(1);
            for(long i = 2; i < 10000; i++)
            {
                pentas.Add(i * (3 * i - 1) / 2);
            }
            long difference = 0;
            long minDifference = long.MaxValue;
            for(int low = 0; low < pentas.Count; low++)
            {
                for(int high = low; high < pentas.Count; high++)
                {
                    difference = pentas[high] - pentas[low];
                    if(EulerUtilities.IsPentagonalNumber(pentas[low] + pentas[high]) && EulerUtilities.IsPentagonalNumber(pentas[high] - pentas[low]) && difference < minDifference)
                    {
                        minDifference = difference;
                    }
                }
            }
            return minDifference;
        }
    }
}
