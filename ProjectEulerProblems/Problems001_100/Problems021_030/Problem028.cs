using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem028
    {
        
        public static int Solve()
        {
            int number = 1, sum = 1, delta = 2;
            int limit = 1001 * 1001;
            int counter = 0;
            while(number < limit)
            {
                number += delta;
                sum += number;
                counter++;
                if(counter % 4 == 0)
                {
                    delta += 2;
                    counter = 0;
                }
            }

            return sum;
        }
        
    }
}
