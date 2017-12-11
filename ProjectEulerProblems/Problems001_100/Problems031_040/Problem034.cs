using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem034
    {
        public static int Solve()
        {
            int totalSum = 0;
            for(int i = 10; i < 2540160; i++)
            {
                int sum = 0;
                foreach(char c in i.ToString())
                {
                    sum += (int) EulerUtilities.Factorial((int) Char.GetNumericValue(c));
                }
                if(sum == i)
                {
                    totalSum += i;
                }
            }
            return totalSum;
        }
    }
}
