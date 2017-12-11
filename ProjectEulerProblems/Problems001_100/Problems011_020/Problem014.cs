using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem014
    {
        public static int Solve()
        {
            long current = 0;
            int longestLength = 0, longestStart = 0;
            int currentLength;
            for(int start = 1000; start < 1000000; start++)
            {
                current = start;
                currentLength = 0;
                while(current != 1)
                {
                    if(current % 2 == 0)
                    {
                        current /= 2;
                    }
                    else
                    {
                        current = (current * 3) + 1;
                    }
                    currentLength++;
                }
                if(currentLength > longestLength)
                {
                    longestStart = start;
                    longestLength = currentLength;
                }
            }

            return longestStart;
        } 
    }
}
