using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem005
    {
        public static int Solve()
        {
            int smallestMultiple = 0;
            for(int i = 20; i < int.MaxValue; i += 20)
            {
                if(i % 19 == 0 && i % 18 == 0 && i % 17 == 0 && i % 16 == 0 && i % 15 == 0 && i % 14 == 0 && i % 13 == 0 && i % 12 == 0 && i % 11 == 0)
                {
                    smallestMultiple = i;
                    break;
                }
            }
            return smallestMultiple;
        } 
    }
}
