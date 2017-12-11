using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectEulerProblems
{
    public class Problem021
    {
        public static int Solve()
        {
            int finalSum = 0;
            for(int i = 4; i < 10000; i += 2)
            {
                int firstSum = EulerUtilities.FindProperDivisors(i).Sum();
                if(firstSum == i)
                {
                    continue;
                }
                int secondSum = EulerUtilities.FindProperDivisors(firstSum).Sum();
                if(i == secondSum)
                {
                    finalSum += firstSum;
                }
            }
            return finalSum;
        }
    }
}
