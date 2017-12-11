using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProjectEulerProblems
{
    public class Problem055
    {
        public static int Solve()
        {
            int count = 0, lychrelCount;
            BigInteger number, reverse, result;
            for(int n = 10; n < 10000; n++)
            {
                lychrelCount = 0;
                number = n;
                reverse = BigInteger.Parse(String.Concat(number.ToString().Reverse()));
                result = number + reverse;
                while(!EulerUtilities.IsPalindrome(result.ToString()) && lychrelCount < 50)
                {
                    number = result;
                    reverse = BigInteger.Parse(String.Concat(number.ToString().Reverse()));
                    result = number + reverse;
                    lychrelCount++;
                }
                if(lychrelCount == 50)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
