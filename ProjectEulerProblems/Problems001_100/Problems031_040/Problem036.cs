using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem036
    {
        public static int Solve()
        {
            int sum = 0;
            for(int i = 1; i < 1000000; i++)
            {
                if(EulerUtilities.IsPalindrome(i.ToString()) && EulerUtilities.IsPalindrome(Convert.ToString(i, 2)))
                {
                    sum += i;
                }
            }
            return sum;
        }
    }
}
