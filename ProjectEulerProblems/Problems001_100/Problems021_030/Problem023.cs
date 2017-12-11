using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem023
    {
        public static int Solve()
        {
            int finalSum = 0;
            List<int> positiveIntegers = new List<int>(Enumerable.Range(1, 28123));
            List<int> abundantIntegers = new List<int>();
            for(int i = 2; i < 28123; i++)
            {
                if(EulerUtilities.FindProperDivisors(i).Sum() > i)
                {
                    abundantIntegers.Add(i);
                }
            }

            int sum;
            for(int outer = 0; outer < abundantIntegers.Count; outer++)
            {
                for(int inner = outer; inner < abundantIntegers.Count; inner++)
                {
                    sum = abundantIntegers[outer] + abundantIntegers[inner];
                    if(sum > 28123)
                    {
                        break;
                    }
                    else
                    {
                        positiveIntegers.Remove(sum);
                    }
                }
            }
            finalSum = positiveIntegers.Sum();
            return finalSum;
        }
    }
}
