using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem012
    {
        public static int Solve()
        {
            int triangleNumber = 1;
            for(int i = 2; i < Int32.MaxValue; i++)
            {
                if(EulerUtilities.FindProperDivisors(triangleNumber).Count > 500)
                {
                    break;
                }
                triangleNumber += i;
            }
            return triangleNumber;
        }
    }
}
