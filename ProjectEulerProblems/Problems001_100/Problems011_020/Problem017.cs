using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem017
    {
        public static int Solve()
        {
            int[] ones = {0, 3, 3, 5, 4, 4, 3, 5, 5, 4 };
            int[] teens = {3, 6, 6, 8, 8, 7, 7, 9, 8, 8 };
            int[] tens = { 0, 3, 6, 6, 5, 5, 5, 7, 6, 6 };

            int count = 11;// One Thousand has 11 characters
            for(int i = 1; i < 1000; i++)
            {
                if((i % 100) < 20 && (i % 100) >= 10)
                {
                    count += teens[(i % 20) - 10];
                }
                else
                {
                    count += ones[i % 10];
                    if(i % 100 >= 20)
                    {
                        count += tens[(i % 100) / 10];
                    }
                }
                if(i >= 100)
                {
                    count += ones[i / 100] + 7;
                    if(i % 100 != 0)
                    {
                        count += 3;
                    }
                }
            }

            return count;
        }
    }
}
