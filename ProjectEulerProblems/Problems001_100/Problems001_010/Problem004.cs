using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem004
    {
        public static int Solve()
        {
            int largestIntegerPalin = 0;
            int product = 0;
            for(int i = 999; i > 900; i--)
            {
                for(int x = 999; x > 900; x--)
                {
                    product = i * x;
                    // Short circuit to do less work on palindrome testing
                    if(product > largestIntegerPalin && EulerUtilities.IsPalindrome(product.ToString()))
                    {
                        largestIntegerPalin = product;
                    }
                }
            }
            return largestIntegerPalin;
        }
    }
}
